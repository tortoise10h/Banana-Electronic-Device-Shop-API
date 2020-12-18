using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using api.Contracts.V1;
using api.Contracts.V1.RequestModels.Auth;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Auth;
using api.Contracts.V1.ResponseModels.User;
using api.CQRS.Auth.Commands.Login;
using api.Services;

namespace api.Controllers.V1
{
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthController(IIdentityService identityService, IMapper mapper, IMediator mediator)
        {
            _identityService = identityService;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> Register(
            [FromBody] UserRegistrationRequest registerInfo)
        {
            var registerResult = await _identityService.RegisterAsync(registerInfo);
            if (!registerResult.IsSuccess)
            {
                return BadRequest(registerResult.Errors);
            }

            var userResponse = _mapper.Map<UserResponse>(registerResult.EntityReturn);
            return Created("", new Response<UserResponse>(userResponse));
        }

        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login(
            [FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                loginResult => Ok(
                    new Response<LoginResponse>(
                        new LoginResponse
                        {
                            Token = loginResult.Token,
                            UserResponse = loginResult.UserResponse,
                            TokenExpireTime = loginResult.TokenExpireTime,
                            RefreshToken = loginResult.RefreshToken
                        }
                    )
                ),
                exp =>
                {
                    throw exp;
                }
            );
        }
    }
}