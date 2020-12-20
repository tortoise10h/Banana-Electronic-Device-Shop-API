using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Common.Enums;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Orders;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace api.CQRS.Orders.Queries
{
    public class GetAllOrdersQuery : PaginationQuery, IRequest<Result<PagedResponse<OrderResponse>>>
    {

    }

    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, Result<PagedResponse<OrderResponse>>>
    {
        private readonly DataContext _context;
        private readonly IPaginationHelpers _paginationHelper;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllOrdersHandler(DataContext context, IMapper mapper, IPaginationHelpers paginationHelper = null, UserManager<ApplicationUser> userManager = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<PagedResponse<OrderResponse>>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.Claims
                .First(x => x.Type == "id").Value;

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);
            var userRole = roles.FirstOrDefault();

            var queryable = _context.Orders.AsQueryable();

            if (userRole == RoleName.Customer)
            {
                queryable = queryable
                    .Where(x => x.CreatedBy == currentUserId)
                    .AsQueryable();
            }

            var result = await _paginationHelper.Paginate<Order, OrderResponse>(
                queryable, query);

            return result;
        }
    }
}