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

namespace api.CQRS.Combos.Commands.CreateCombos
{
    public class CreateComboCommand : IRequest<Result<ComboResponse>>
    {
        public string Name { get; set; }
        public double DiscountPercentage { get; set; }
        public List<CreateComboDetailCommand> ComboDetails { get; set; }
    }

    public class CreateComboHandler : IRequestHandler<CreateComboCommand, Result<ComboResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPriceCalculateHelpers _priceCalculateHelpers;

        public CreateComboHandler(
            DataContext context, IMapper mapper, IPriceCalculateHelpers priceCalculateHelpers)
        {
            _context = context;
            _mapper = mapper;
            _priceCalculateHelpers = priceCalculateHelpers;
        }

        public async Task<Result<ComboResponse>> Handle(
            CreateComboCommand request,
            CancellationToken cancellationToken)
        {
            /** Validate product of new combo */
            var productIds = request.ComboDetails.Select(x => x.ProductId);
            var existedProducts = await _context.Products
                .Where(x => productIds.Contains(x.Id))
                .ToListAsync();
            if (existedProducts.Count() != productIds.Count())
            {
                throw new NotFoundException();
            }

            /** Prepare new information for new combo */
            double price = 0;
            foreach (var product in existedProducts)
            {
                var matchedComboDetail = request.ComboDetails
                    .SingleOrDefault(x => x.ProductId == product.Id);

                price += (product.Price * matchedComboDetail.Quantity);
            }
            var discountPrice = _priceCalculateHelpers.CalculateDiscountPrice(
                price,
                request.DiscountPercentage
            );

            var newComboEntity = _mapper.Map<Combo>(request);
            newComboEntity.Price = price;
            newComboEntity.PriceForSale = discountPrice;

            await _context.Combos.AddAsync(newComboEntity);
            var created = await _context.SaveChangesAsync();
            if (created > 0)
            {
                return new Result<ComboResponse>(
                    _mapper.Map<ComboResponse>(newComboEntity)
                );
            }

            return new Result<ComboResponse>(
                new BadRequestException(new ApiError("Tạo combo sản phẩm xảy ra lỗi, xin thử lại"))
            );
        }
    }
}
