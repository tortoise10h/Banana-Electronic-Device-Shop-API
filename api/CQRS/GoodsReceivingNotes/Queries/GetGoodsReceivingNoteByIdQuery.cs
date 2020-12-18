using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.GoodsReceivingNotes;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.GoodsReceivingNotes.Queries
{
    public class GetGoodsReceivingNoteByIdQuery : IRequest<Result<GoodsReceivingNoteResponse>>
    {
        public GetGoodsReceivingNoteByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetGoodsReceivingNoteByIdHandler : IRequestHandler<GetGoodsReceivingNoteByIdQuery, Result<GoodsReceivingNoteResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetGoodsReceivingNoteByIdHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Result<GoodsReceivingNoteResponse>> Handle(GetGoodsReceivingNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.GoodsReceivingNotes.AsQueryable();

            queryable = queryable
                .Include(grn => grn.GoodsReceivingDetails)
                    .ThenInclude(grd => grd.Product)
                .Where(
                    grn => grn.Id == request.Id);

            var goodsReceivingNote = await queryable.FirstOrDefaultAsync();

            if (goodsReceivingNote == null)
            {
                return new Result<GoodsReceivingNoteResponse>(
                    new NotFoundException()
                );
            }

            return new Result<GoodsReceivingNoteResponse>(
                _mapper.Map<GoodsReceivingNoteResponse>(goodsReceivingNote)
            );
        }
    }
}