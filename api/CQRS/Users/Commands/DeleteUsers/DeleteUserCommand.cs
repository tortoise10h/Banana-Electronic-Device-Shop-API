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

namespace api.CQRS.Users.Commands.DeleteUsers
{
    public class DeleteUserCommand : IRequest<Result<UserResponse>>
    {
        public string UserId { get; set; }
    }

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<UserResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteUserHandler(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<UserResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
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
                        new ApiError("Bạn không có quyền xoá tài khoản")));
            }

            if (userRole == RoleName.Admin && (role[0] == RoleName.Admin || role[0] == RoleName.SuperAdmin))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền xoá tài khoản Admin và SuperAdmin")));
            }

            if ((userRole == RoleName.Boss) && (role[0] == RoleName.Admin || role[0] == RoleName.SuperAdmin || role[0] == RoleName.Boss))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có xoá tài khoản Quản trị viên, Quản trị viên cấp cao và Ban lãnh đạo")));
            }

            var minutes = user.CreatedAt.Minute;

            if (minutes > 10)
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Chỉ có thể xoá user khi được tạo trong vòng 10 phút")));
            }

            var deleted = await _userManager.DeleteAsync(user);

            if (deleted.Succeeded)
            {
                return new Result<UserResponse>(
                    _mapper.Map<UserResponse>(user)
                );
            }

            return new Result<UserResponse>(
               new BadRequestException(new ApiError("Xoá user thất bại, vui lòng thử lại"))
            );
        }
    }
}