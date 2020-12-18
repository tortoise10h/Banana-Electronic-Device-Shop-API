using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Auth;
using api.Entities;
using api.Services;

namespace api.CQRS.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result<LoginResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginHandler : IRequestHandler<LoginCommand, Result<LoginResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _identityService;

        public LoginHandler(UserManager<ApplicationUser> userManager, IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
        }
        public async Task<Result<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                return new Result<LoginResult>(
                    new BadRequestException(new ApiError("Tài khoản không tồn tại"))
                );
            }

            if (user != null && user.LockoutEnabled == true)
            {
                return new Result<LoginResult>(
                    new BadRequestException(new ApiError("Tài khoản đã bị khoá"))
                );
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!userHasValidPassword)
            {
                return new Result<LoginResult>(
                    new BadRequestException(new ApiError("Email or password is incorrect"))
                );
            }

            var loginResult = await _identityService.GenerateLoginResult(user);
            return new Result<LoginResult>(
                loginResult
            );
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}