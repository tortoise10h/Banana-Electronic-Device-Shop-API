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
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Orders.Commands.UpdateOrders
{
    public class UpdateOrderCommand : IRequest<Result<OrderResponse>>
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Result<OrderResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<OrderResponse>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (order == null)
            {
                return new Result<OrderResponse>(
                    new NotFoundException()
                );
            }

            if (order.Status == OrderStatus.Done || order.Status == OrderStatus.Cancelled)
            {
                throw new BadRequestException(
                    new ApiError("Đơn hàng này không được phép chỉnh sửa"));
            }

            var orderDetails = await _context.OrderDetails
                .Where(x => x.OrderId == order.Id)
                .ToListAsync();

            var productIds = orderDetails
                .Select(x => x.ProductId)
                .ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            var quantityLogs = orderDetails
                .Select(x => new QuantityLog
                {
                    ProductId = x.ProductId
                })
                .ToList();

            if (request.Status == OrderStatus.Done)
            {
                foreach (var item in quantityLogs)
                {
                    var currentQuantity = products
                        .FirstOrDefault(x => x.Id == item.ProductId);

                    var newQuantity = orderDetails
                        .FirstOrDefault(x => x.ProductId == item.ProductId);

                    item.InStock = currentQuantity.Quantity - newQuantity.Quantity;
                }

                foreach (var p in products)
                {
                    var update = orderDetails
                        .FirstOrDefault(x => x.ProductId == p.Id);

                    p.Quantity -= update.Quantity;
                }

                _context.Products.UpdateRange(products);
                _context.QuantityLogs.AddRange(quantityLogs);
            }

            _mapper.Map<UpdateOrderCommand, Order>(request, order);

            _context.Orders.Update(order);
            var updated = await _context.SaveChangesAsync();

            if (updated > 0)
            {
                return new Result<OrderResponse>(
                    _mapper.Map<OrderResponse>(order)
                );
            }

            return new Result<OrderResponse>(
                new BadRequestException(
                    new ApiError("Chỉnh sửa thông tin của đơn hàng thất bại, xin thử lại"))
            );
        }
    }
}