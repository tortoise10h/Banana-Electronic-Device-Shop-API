using System.Collections.Generic;
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

namespace api.CQRS.Orders.Commands.CreateOrders
{
    public class CreateOrderCommand : IRequest<Result<OrderResponse>>
    {
        public string DeliveryAddress { get; set; }
        public string Description { get; set; }
        public List<ProductInOrderDetails> OrderDetails { get; set; }
    }

    public class CreateOrdersHandler : IRequestHandler<CreateOrderCommand, Result<OrderResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateOrdersHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var productIds = request.OrderDetails
                .Select(p => p.ProductId)
                .ToList();

            // Validate product id is unique
            var distinctProductIds = request.OrderDetails
                .Select(p => p.ProductId)
                .Distinct()
                .ToList();

            if (productIds.Count() != distinctProductIds.Count())
            {
                return new Result<OrderResponse>(
                    new BadRequestException(
                        new ApiError("Mỗi sản phẩm chỉ được thêm vào đơn hàng 1 lần")
                    )
                );
            }

            // Validate products exist
                var products = await _context.Products
                    .Where(p => productIds.Contains(p.Id))
                    .ToListAsync();

            if (distinctProductIds.Count() != products.Count())
            {
                return new Result<OrderResponse>(
                    new BadRequestException(
                        new ApiError("Có sản phẩm không tồn tại")
                    )
                );
            }

            var order = _mapper.Map<Order>(request);

            order.Status = OrderStatus.New;

            double sum = 0;
            foreach (var item in order.OrderDetails)
            {
                var update = products
                    .SingleOrDefault(x => x.Id == item.ProductId);

                if (update.Quantity < item.Quantity)
                {
                    return new Result<OrderResponse>(
                        new BadRequestException(
                            new ApiError("Số lượng sản phẩm trong kho không còn đủ")
                        )
                    );
                }

                item.UnitPrice = update.Price;
                item.TotalPrice = item.UnitPrice * item.Quantity;
                sum += item.TotalPrice;
            }
            order.TotalPrice = sum;

            await _context.AddAsync(order);
            var created = await _context.SaveChangesAsync();

            if (created > 0)
            {
                return new Result<OrderResponse>(
                    _mapper.Map<OrderResponse>(order)
                );
            }

            return new Result<OrderResponse>(
                _mapper.Map<OrderResponse>(
                    new BadRequestException(new ApiError("Tạo đơn hàng thất bại, xin thử lại"))
                )
            );
        }
    }
}