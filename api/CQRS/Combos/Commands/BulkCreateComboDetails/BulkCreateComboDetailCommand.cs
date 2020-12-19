using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Combos;
using api.CQRS.Combos.Commands.CreateComboDetails;
using api.Entities;
using api.Helpers;
using api.Services;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.BulkCreateComboDetails
{
    public class BulkCreateComboDetailCommand : IRequest<Result<List<ComboDetailResponse>>>
    {
        public int ComboId { get; set; }
        public List<CreateComboDetailCommand> ComboDetails { get; set; }
    }

    public class BulkCreateComboDetailHandler : IRequestHandler<BulkCreateComboDetailCommand, Result<List<ComboDetailResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPriceCalculateHelpers _priceCalculateHelpers;

        public BulkCreateComboDetailHandler(
            DataContext context, IMapper mapper, IPriceCalculateHelpers priceCalculateHelpers)
        {
            _context = context;
            _mapper = mapper;
            _priceCalculateHelpers = priceCalculateHelpers;
        }

        public async Task<Result<List<ComboDetailResponse>>> Handle(
            BulkCreateComboDetailCommand request,
            CancellationToken cancellationToken)
        {
            /** Validate combo existed */
            var combo = await _context.Combos
                .Include(x => x.ComboDetails)
                .SingleOrDefaultAsync(x => x.Id == request.ComboId);
            if (combo == null)
            {
                return new Result<List<ComboDetailResponse>>(
                    new NotFoundException()
                );
            }

            /** Validate new products valid */
            var productIds = request.ComboDetails.Select(x => x.ProductId);
            var existedProducts = await _context.Products
                .Where(x => productIds.Contains(x.Id))
                .ToListAsync();
            if (productIds.Count() != existedProducts.Count())
            {
                return new Result<List<ComboDetailResponse>>(
                    new NotFoundException()
                );
            }

            bool isProductDuplicated = combo.ComboDetails
                .Any(x => productIds.Contains(x.ProductId));
            if (isProductDuplicated)
            {
                return new Result<List<ComboDetailResponse>>(
                    new BadRequestException(
                        new ApiError(
                            "Có sản phẩm đã tồn tại trong combo"))
                );
            }

            /** Prepare info to save to DB */
            // Combo detail
            var newComboDetailEntities = _mapper.Map<List<ComboDetail>>(request.ComboDetails);
            foreach (var comboDetail in newComboDetailEntities)
            {
                comboDetail.ComboId = combo.Id;
            }

            // Combo
            double plusAmount = 0;
            foreach (var product in existedProducts)
            {
                var matchedComboDetail = request.ComboDetails
                    .SingleOrDefault(x => x.ProductId == product.Id);

                plusAmount += product.Price * matchedComboDetail.Quantity;
            }

            combo.Price += plusAmount;
            combo.PriceForSale = _priceCalculateHelpers.CalculateDiscountPrice(
                combo.Price,
                combo.DiscountPercentage
            );


            await _context.ComboDetails.AddRangeAsync(newComboDetailEntities);
            _context.Combos.Update(combo);

            await _context.SaveChangesAsync();

            return new Result<List<ComboDetailResponse>>(
                _mapper.Map<List<ComboDetailResponse>>(newComboDetailEntities)
            );
        }
    }
}
