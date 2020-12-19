using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Combos;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Combos.Commands.DeleteCombos
{
    public class DeleteComboHandler : IRequestHandler<DeleteComboCommand, Result<ComboResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DeleteComboHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ComboResponse>> Handle(
            DeleteComboCommand request,
            CancellationToken cancellationToken)
        {
            var combo = await _context.Combos
                .Include(x => x.ComboDetails)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (combo == null)
            {
                throw new NotFoundException("Combo sản phẩm không tồn tại");
            }

            _context.ComboDetails.RemoveRange(combo.ComboDetails);
            _context.Combos.Remove(combo);

            await _context.SaveChangesAsync();
            return new Result<ComboResponse>(
                _mapper.Map<ComboResponse>(combo)
            );
        }
    }
}