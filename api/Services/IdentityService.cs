using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using api.Contracts.V1.RequestModels.Auth;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Auth;
using api.Contracts.V1.ResponseModels.User;
using api.Entities;
using api.Helpers;

namespace api.Services
{
    public interface IIdentityService
    {
        Task<CreateResult<ApplicationUser>> RegisterAsync(UserRegistrationRequest registerInfo);
        Task<LoginResult> GenerateLoginResult(ApplicationUser user);
        Task<LoginResult> LoginAsync(string email, string password);
    }

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            IOptions<AppSettings> appSettings,
            IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new LoginResult
                {
                    IsSuccess = false,
                    Errors = new List<string>() {
                        "User does not exist"
                    }
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return new LoginResult
                {
                    IsSuccess = false,
                    Errors = new List<string>() {
                        "Email or password is incorrect"
                    }
                };
            }

            return await GenerateLoginResult(user);
        }

        public async Task<LoginResult> GenerateLoginResult(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenExpireTime = DateTime.UtcNow.Add(_appSettings.TokenLifeTime);

            var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id),
                };

            /** Get all claims of user to add to JWT token */
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            /** Get user roles of user and add to JWT token */
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null) continue;

                /** If role has claims then add them to JWT token too */
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                foreach (var roleClaim in roleClaims)
                {
                    /** Prevent duplicate between role claim and user claim */
                    if (claims.Contains(roleClaim))
                        continue;

                    claims.Add(roleClaim);
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpireTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return new LoginResult
            {
                IsSuccess = true,
                Token = tokenString,
                TokenExpireTime = tokenExpireTime,
                UserResponse = _mapper.Map<UserResponse>(user),
            };
        }

        public async Task<CreateResult<ApplicationUser>> RegisterAsync(
            UserRegistrationRequest registerInfo)
        {
            var existedUserEmail = await _userManager.FindByEmailAsync(registerInfo.Email);
            if (existedUserEmail != null)
            {
                return new CreateResult<ApplicationUser>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "This email is already existed" }
                };
            }

            var newUser = new ApplicationUser
            {
                Email = registerInfo.Email,
                UserName = registerInfo.Email,
                FirstName = registerInfo.FirstName,
                LastName = registerInfo.LastName,
                PhoneNumber = registerInfo.Phone
            };

            var createdUser = await _userManager.CreateAsync(newUser, registerInfo.Password);

            if (!createdUser.Succeeded)
            {
                return new CreateResult<ApplicationUser>
                {
                    IsSuccess = false,
                    Errors = new List<string>(createdUser.Errors.Select(x => x.Description))
                };
            }

            return new CreateResult<ApplicationUser>
            {
                IsSuccess = true,
                EntityReturn = newUser
            };
        }
    }
}