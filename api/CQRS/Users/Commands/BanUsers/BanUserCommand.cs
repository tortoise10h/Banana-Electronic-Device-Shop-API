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

namespace api.CQRS.Users.Commands.BanUsers
{
    public class BanUserCommand : IRequest<Result<UserResponse>>
    {
        public string UserId { get; set; }
        public bool Status { get; set; }
    }

    public class BanUserHandler : IRequestHandler<BanUserCommand, Result<UserResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BanUserHandler(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<UserResponse>> Handle(BanUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new Result<UserResponse>(
                    new NotFoundException()
                );
            }

            var role = await _userManager.GetRolesAsync(user);

            /** Only superadmin and admin can delete user */
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
                        new ApiError("Bạn không có quyền khoá tài khoản")));
            }

            if (userRole == RoleName.Admin && (role[0] == RoleName.Admin || role[0] == RoleName.SuperAdmin))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền khoá tài khoản Quản trị viên và Quản trị viên cấp cao")));
            }

            if ((userRole == RoleName.Boss) && (role[0] == RoleName.Admin || role[0] == RoleName.SuperAdmin || role[0] == RoleName.Boss))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền khoá tài khoản Quản trị viên, Quản trị viên cấp cao và Ban lãnh đạo")));
            }

            user.LockoutEnabled = request.Status;

            _context.Users.Update(user);

            var updated = await _context.SaveChangesAsync();

            if (updated > 0)
            {
                return new Result<UserResponse>(
                    _mapper.Map<UserResponse>(user)
                );
            }

            return new Result<UserResponse>(
               new BadRequestException(new ApiError("Khoá tài khoản thất bại, vui lòng thử lại"))
            );
        }
    }
}