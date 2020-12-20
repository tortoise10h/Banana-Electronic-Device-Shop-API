using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Orders;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Orders.Queries
{
    public class GetOrdersByIdQuery : IRequest<Result<OrderResponse>>
    {
        public GetOrdersByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrdersByIdQuery, Result<OrderResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public GetOrderByIdHandler(IMapper mapper, DataContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result<OrderResponse>> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.Claims
                .First(x => x.Type == "id").Value;

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);
            var userRole = roles.FirstOrDefault();

            var queryable = _context.Orders.AsQueryable();

            queryable = queryable
                .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                .Where(x => x.Id == request.Id);

            if (userRole == RoleName.Customer)
            {
                queryable = queryable
                    .Include(x => x.OrderDetails)
                        .ThenInclude(x => x.Product)
                    .Where(x => x.Id == request.Id && x.CreatedBy == currentUserId);
            }

            var order = await queryable.FirstOrDefaultAsync();

            if (order == null)
            {
                return new Result<OrderResponse>(
                    new NotFoundException()
                );
            }

            return new Result<OrderResponse>(
                _mapper.Map<OrderResponse>(order)
            );
        }
    }
}