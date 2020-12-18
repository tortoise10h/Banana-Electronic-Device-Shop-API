using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.User;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace api.CQRS.Users.Queries
{
    public class GetAllUsersQuery : PaginationQuery, IRequest<Result<PagedResponse<UserResponse>>>
    {

    }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<PagedResponse<UserResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginationHelpers _paginationHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetAllUsersHandler(DataContext context, IMapper mapper, IPaginationHelpers paginationHelper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<PagedResponse<UserResponse>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var queryable = _userManager.Users.AsQueryable();

            var result = await _paginationHelper.Paginate<ApplicationUser, UserResponse>(
                queryable, query);

            var userIdsResult = result.Data
                .Select(x => x.Id)
                .ToList();

            var userRoles = await _context.UserRoles
                .Where(x => userIdsResult.Contains(x.UserId))
                .Join(_context.Roles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => new
                    {
                        RoleName = r.Name,
                        UserId = ur.UserId
                    })
                .ToListAsync();

            foreach (var item in result.Data)
            {
                var matchedUserRole = userRoles
                    .SingleOrDefault(x => x.UserId == item.Id);

                var matchedStatus = queryable
                    .SingleOrDefault(x => x.Id == item.Id);

                item.Status = matchedStatus.LockoutEnabled;
                item.RoleName = matchedUserRole.RoleName;
            }

            return result;
        }
    }
}