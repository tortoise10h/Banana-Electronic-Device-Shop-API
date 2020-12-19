using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.GoodsReceivingNotes;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.GoodsReceivingNotes.Commands.DeleteGoodsReceivingNotes
{
    public class DeleteGoodsReceivingNotesCommand : IRequest<Result<GoodsReceivingNoteResponse>>
    {
        public DeleteGoodsReceivingNotesCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteGoodsReceivingNotesHandler : IRequestHandler<DeleteGoodsReceivingNotesCommand, Result<GoodsReceivingNoteResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DeleteGoodsReceivingNotesHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GoodsReceivingNoteResponse>> Handle(DeleteGoodsReceivingNotesCommand request, CancellationToken cancellationToken)
        {
            var goodsReceivingNote = await _context.GoodsReceivingNotes.SingleOrDefaultAsync(
                x => x.Id == request.Id
            );

            if (goodsReceivingNote == null)
            {
                return new Result<GoodsReceivingNoteResponse>(
                    new NotFoundException()
                );
            }

            var goodsReceivingDetails = await _context.GoodsReceivingDetails
                .Where(x => x.GoodsReceivingNoteId == request.Id)
                .ToListAsync();

            var productIds = goodsReceivingDetails
                .Select(x => x.ProductId)
                .ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            var quantityLogs = goodsReceivingDetails
                .Select(x => new QuantityLog
                {
                    ProductId = x.ProductId
                })
                .ToList();

            foreach (var item in quantityLogs)
            {
                var currentQuantity = products
                    .FirstOrDefault(x => x.Id == item.ProductId);

                var newQuantity = goodsReceivingDetails
                    .FirstOrDefault(x => x.ProductId == item.ProductId);

                item.InStock = currentQuantity.Quantity - newQuantity.Quantity;
            }

            foreach (var p in products)
            {
                var update = goodsReceivingDetails
                    .FirstOrDefault(x => x.ProductId == p.Id);

                p.Quantity -= update.Quantity;
            }

            _context.Products.UpdateRange(products);
            _context.QuantityLogs.AddRange(quantityLogs);
            _context.GoodsReceivingDetails.RemoveRange(goodsReceivingDetails);
            _context.GoodsReceivingNotes.Remove(goodsReceivingNote);

            var deleted = await _context.SaveChangesAsync();

            if (deleted > 0)
            {
                return new Result<GoodsReceivingNoteResponse>(
                    _mapper.Map<GoodsReceivingNoteResponse>(goodsReceivingNote)
                );
            }

            return new Result<GoodsReceivingNoteResponse>(
                new BadRequestException(
                    new ApiError("Xoá phiếu nhập kho xảy ra lỗi, xin thử lại"))
            );

        }
    }
}