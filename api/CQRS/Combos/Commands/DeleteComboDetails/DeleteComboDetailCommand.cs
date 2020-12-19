using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Combos;
using api.Entities;
using api.Helpers;
using api.Services;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.DeleteComboDetails
{
    public class DeleteComboDetailCommand : IRequest<Result<ComboDetailResponse>>
    {
        public DeleteComboDetailCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public int ComboId { get; set; }
    }

    public class DeleteComboDetailHandler : IRequestHandler<DeleteComboDetailCommand, Result<ComboDetailResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPriceCalculateHelpers _priceCalculateHelpers;

        public DeleteComboDetailHandler(
            DataContext context, IMapper mapper, IPriceCalculateHelpers priceCalculateHelpers)
        {
            _context = context;
            _mapper = mapper;
            _priceCalculateHelpers = priceCalculateHelpers;
        }

        public async Task<Result<ComboDetailResponse>> Handle(
            DeleteComboDetailCommand request,
            CancellationToken cancellationToken)
        {
            var combo = await _context.Combos
                .SingleOrDefaultAsync(x => x.Id == request.ComboId);
            if (combo == null)
            {
                return new Result<ComboDetailResponse>(
                    new NotFoundException()
                );
            }

            var comboDetail = await _context.ComboDetails
                .SingleOrDefaultAsync(x => x.Id == request.Id);
            if (comboDetail == null)
            {
                throw new NotFoundException();
            }

            var product = await _context.Products
                .SingleOrDefaultAsync(x => x.Id == comboDetail.ProductId);

            if (comboDetail.ComboId != combo.Id)
            {
                return new Result<ComboDetailResponse>(
                    new BadRequestException(
                        new ApiError(
                            $"Trong combo \"{combo.Name}\" không có sản phẩm này"
                        )
                    )
                );
            }

            var existedOrderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(x => x.ComboId == comboDetail.ComboId &&
                    x.ProductId == comboDetail.ProductId);
            if (existedOrderDetail != null)
            {
                return new Result<ComboDetailResponse>(
                    new BadRequestException(
                        new ApiError("Không thể xoá sản phẩm trong combo này vì còn tồn tại đơn hàng sử dụng nó"))
                );
            }

            /** Update price of combo delete a product in that combo */
            combo.Price -= comboDetail.Quantity * product.Price;
            combo.PriceForSale = _priceCalculateHelpers
                .CalculateDiscountPrice(
                    combo.Price,
                    combo.DiscountPercentage
                );

            _context.ComboDetails.Remove(comboDetail);
            _context.Combos.Update(combo);
            await _context.SaveChangesAsync();

            return new Result<ComboDetailResponse>(
                    _mapper.Map<ComboDetailResponse>(comboDetail)
                );
        }
    }
}
