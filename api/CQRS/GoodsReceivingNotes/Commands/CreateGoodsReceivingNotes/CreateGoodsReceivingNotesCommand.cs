using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.GoodsReceivingNotes;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;

namespace api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingNotes
{
    public class CreateGoodsReceivingNotesCommand : IRequest<Result<GoodsReceivingNoteResponse>>
    {
        public string SupplierName { get; set; }
        public string Description { get; set; }
    }

    public class CreateGoodsReceivingNotesHandler : IRequestHandler<CreateGoodsReceivingNotesCommand, Result<GoodsReceivingNoteResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateGoodsReceivingNotesHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GoodsReceivingNoteResponse>> Handle(CreateGoodsReceivingNotesCommand request, CancellationToken cancellationToken)
        {
            var goodsReceivingNote = _mapper.Map<GoodsReceivingNote>(request);
            goodsReceivingNote.TotalPrice = 0;

            await _context.AddAsync(goodsReceivingNote);
            var created = await _context.SaveChangesAsync();

            if (created > 0)
            {
                return new Result<GoodsReceivingNoteResponse>(
                    _mapper.Map<GoodsReceivingNoteResponse>(goodsReceivingNote)
                );
            }

            return new Result<GoodsReceivingNoteResponse>(
               new BadRequestException(new ApiError("Tạo phiếu nhập kho thất bại, vui lòng thử lại"))
            );
        }
    }
}