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

namespace api.CQRS.Combos.Commands.UpdateComboDetails
{
    public class UpdateComboDetailCommand : IRequest<Result<ComboDetailResponse>>
    {
        public int ComboId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateComboDetailHandler : IRequestHandler<UpdateComboDetailCommand, Result<ComboDetailResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPriceCalculateHelpers _priceCalculateHelpers;

        public UpdateComboDetailHandler(
            DataContext context, IMapper mapper, IPriceCalculateHelpers priceCalculateHelpers)
        {
            _context = context;
            _mapper = mapper;
            _priceCalculateHelpers = priceCalculateHelpers;
        }

        public async Task<Result<ComboDetailResponse>> Handle(
            UpdateComboDetailCommand request,
            CancellationToken cancellationToken)
        {
            /** Make sure update info valid */
            var combo = await _context.Combos
                .SingleOrDefaultAsync(x => x.Id == request.ComboId);
            if (combo == null)
            {
                return new Result<ComboDetailResponse>(
                    new NotFoundException()
                );
            }

            var comboDetail = await _context.ComboDetails
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == request.Id);
            if (comboDetail == null)
            {
                return new Result<ComboDetailResponse>(
                    new NotFoundException()
                );
            }
            int oldQuantity = comboDetail.Quantity;

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

            _mapper.Map<UpdateComboDetailCommand, ComboDetail>(request, comboDetail);

            /** Update price of combo after quantity of combo detail is edited */
            combo.Price -= oldQuantity * comboDetail.Product.Price;
            combo.Price += comboDetail.Quantity * comboDetail.Product.Price;
            combo.PriceForSale = _priceCalculateHelpers
                .CalculateDiscountPrice(
                    combo.Price,
                    combo.DiscountPercentage
                );

            _context.ComboDetails.Update(comboDetail);
            _context.Combos.Update(combo);
            await _context.SaveChangesAsync();

            return new Result<ComboDetailResponse>(
                    _mapper.Map<ComboDetailResponse>(comboDetail)
                );
        }
    }
}
