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

namespace api.CQRS.Users.Commands.UpdateUsers
{
    public class UpdateUserCommand : IRequest<Result<UserResponse>>
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<UserResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UpdateUserHandler(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new Result<UserResponse>(
                    new NotFoundException()
                );
            }

            var role = await _userManager.GetRolesAsync(user);

            /** Only superadmin and admin can update user */
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
                        new ApiError("Bạn không có quyền cập nhật tài khoản")));
            }

            if (userRole == RoleName.Admin && currentUser.Id != request.UserId && role[0] == RoleName.Admin)
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền cập nhật tài khoản của các Quản trị viên khác")));
            }

            if (userRole == RoleName.Admin && (request.RoleName == RoleName.SuperAdmin || request.RoleName == RoleName.Admin))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có quyền cập nhật tài khoản lên Quản trị viên hoặc Quản trị viên cấp cao")));
            }

            if ((userRole == RoleName.Boss) && (role[0] == RoleName.Admin || role[0] == RoleName.SuperAdmin || role[0] == RoleName.Boss))
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Bạn không có cập nhật tài khoản lên Quản trị viên, Quản trị viên cấp cao và Ban lãnh đạo")));
            }

            //** Validate email exist */
            var userEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userEmail != null && userEmail.Id != request.UserId)
            {
                return new Result<UserResponse>(
                    new BadRequestException(
                        new ApiError("Email đã tồn tại vui lòng thử email khác")));
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.Email;
            user.NormalizedUserName = request.Email.ToUpper();
            user.Email = request.Email;
            user.NormalizedEmail = request.Email.ToUpper();
            user.PhoneNumber = request.PhoneNumber;

            await _userManager.RemoveFromRoleAsync(user, role[0]);
            await _userManager.AddToRoleAsync(user, request.RoleName);

            _context.Users.Update(user);

            var updated = await _context.SaveChangesAsync();

            if (updated > 0)
            {
                return new Result<UserResponse>(
                    _mapper.Map<UserResponse>(user)
                );
            }

            return new Result<UserResponse>(
               new BadRequestException(new ApiError("Cập nhật user thất bại, vui lòng thử lại"))
            );
        }
    }
}