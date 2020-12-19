using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using api.Contracts.V1.Exceptions;
using api.Helpers;
using api.Entities;
using api.Contracts.V1.ResponseModels.Combos;

namespace api.CQRS.Combos.Commands.UpdateCombos
{
    public class UpdateComboCommand : IRequest<Result<ComboResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DiscountPercentage { get; set; }
    }

    public class UpdateComboHandler : IRequestHandler<UpdateComboCommand, Result<ComboResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPriceCalculateHelpers _priceCalculateHelpers;

        public UpdateComboHandler(DataContext context, IMapper mapper, IPriceCalculateHelpers priceCalculateHelpers)
        {
            _context = context;
            _mapper = mapper;
            _priceCalculateHelpers = priceCalculateHelpers;
        }

        public async Task<Result<ComboResponse>> Handle(
            UpdateComboCommand request,
            CancellationToken cancellationToken)
        {
            var combo = await _context.Combos
                .SingleOrDefaultAsync(
                    x => x.Id == request.Id
                );
            if (combo == null)
            {
                return new Result<ComboResponse>(
                    new NotFoundException()
                );
            }

            if (combo.DiscountPercentage != request.DiscountPercentage)
            {
                /** If discount percentage is changed then we have to re-calculate
                * the price of combo */
                combo.PriceForSale = _priceCalculateHelpers.CalculateDiscountPrice(
                    combo.Price,
                    request.DiscountPercentage
                );
            }

            _mapper.Map<UpdateComboCommand, Combo>(request, combo);

            _context.Combos.Update(combo);
            await _context.SaveChangesAsync();

            return new Result<ComboResponse>(
                    _mapper.Map<ComboResponse>(combo)
                );
        }
    }
}