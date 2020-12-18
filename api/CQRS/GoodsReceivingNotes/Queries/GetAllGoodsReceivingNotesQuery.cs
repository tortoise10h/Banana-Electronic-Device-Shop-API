using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.GoodsReceivingNotes;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.GoodsReceivingNotes.Queries
{
    public class GetAllGoodsReceivingNotesQuery : PaginationQuery, IRequest<Result<PagedResponse<GoodsReceivingNoteResponse>>>
    {

    }

    public class GetAllGoodsReceivingNotesHandler : IRequestHandler<GetAllGoodsReceivingNotesQuery, Result<PagedResponse<GoodsReceivingNoteResponse>>>
    {
        private readonly DataContext _context;
        private readonly IPaginationHelpers _paginationHelper;
        private readonly IMapper _mapper;

        public GetAllGoodsReceivingNotesHandler(DataContext context, IMapper mapper, IPaginationHelpers paginationHelper = null)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
        }
        public async Task<Result<PagedResponse<GoodsReceivingNoteResponse>>> Handle(GetAllGoodsReceivingNotesQuery query, CancellationToken cancellationToken)
        {
            var queryable = _context.GoodsReceivingNotes.AsQueryable();

            var result = await _paginationHelper.Paginate<GoodsReceivingNote, GoodsReceivingNoteResponse>(
                queryable, query);

            return result;
        }
    }
}