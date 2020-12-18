using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.User;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Users.Commands.CreateUsers
{
    public class CreateUserCommand : IRequest<Result<UserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<UserResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserHandler(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor = null, UserManager<ApplicationUser> userManager = null)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Result<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            /** Only superadmin and admin can create user */
            var currentUserId = _httpContextAccessor.HttpContext.User
                    .Claims
                        .First(x => x.Type == "id").Value;

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);
            var userRole = roles.FirstOrDefault();

            if (userRole != RoleName.Admin && userRole != RoleName.SuperAdmin && userRole != RoleName.Boss)
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền tạo tài khoản")));
            }

            if ((userRole == RoleName.Admin) && (request.RoleName == RoleName.Admin || request.RoleName == RoleName.SuperAdmin))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền tạo tài khoản Quản trị viên và Quản trị viên cấp cao")));
            }

            if ((userRole == RoleName.Boss) && (request.RoleName == RoleName.Admin || request.RoleName == RoleName.SuperAdmin || request.RoleName == RoleName.Boss))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền tạo tài khoản Quản trị viên, Quản trị viên cấp cao và Ban lãnh đạo")));
            }

            //** Validate email exist */
            var existEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existEmail != null)
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Email đã tồn tại vui lòng thử email khác")));
            }

            var hasher = new PasswordHasher<ApplicationUser>();
            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, request.Password),
                PhoneNumber = request.PhoneNumber,
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now
            };

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == request.RoleName);

            var newUserRole = new IdentityUserRole<string>
            {
                UserId = newUser.Id,
                RoleId = role.Id
            };

            await _context.Users.AddAsync(newUser);
            await _context.UserRoles.AddAsync(newUserRole);
            var created = await _context.SaveChangesAsync();

            if (created > 0)
            {
                return new Result<UserResponse>(
                    _mapper.Map<UserResponse>(newUser)
                );
            }

            return new Result<UserResponse>(
               new BadRequestException(new ApiError("Tạo user thất bại, vui lòng thử lại"))
            );
        }
    }
}