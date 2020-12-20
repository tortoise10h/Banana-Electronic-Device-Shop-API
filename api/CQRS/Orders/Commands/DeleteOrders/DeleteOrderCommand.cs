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

namespace api.CQRS.Orders.Commands.DeleteOrders
{
    public class DeleteOrderCommand : IRequest<Result<OrderResponse>>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Result<OrderResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DeleteOrderHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<OrderResponse>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
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
                    new ApiError("Đơn hàng này không được phép xoá"));
            }

            var orderDetails = await _context.OrderDetails
               .Where(x => x.OrderId == order.Id)
               .ToListAsync();

            _context.RemoveRange(orderDetails);
            _context.Remove(order);

            var deleted = await _context.SaveChangesAsync();

            if (deleted > 0)
            {
                return new Result<OrderResponse>(
                    _mapper.Map<OrderResponse>(order)
                );
            }

            return new Result<OrderResponse>(
                new BadRequestException(
                    new ApiError("Xoá đơn hàng xảy ra lỗi, xin thử lại"))
            );
        }
    }
}