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

namespace api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingDetails
{
    public class CreateGoodsReceivingDetailsCommand : IRequest<Result<List<GoodsReceivingDetailResponse>>>
    {
        public int GoodsReceivingNoteId { get; set; }
        public List<ProductInGoodsReceivingDetails> Products { get; set; }
    }

    public class CreateGoodsReceivingDetailsHandler : IRequestHandler<CreateGoodsReceivingDetailsCommand, Result<List<GoodsReceivingDetailResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateGoodsReceivingDetailsHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<List<GoodsReceivingDetailResponse>>> Handle(CreateGoodsReceivingDetailsCommand request, CancellationToken cancellationToken)
        {
            var goodsReceivingNote = await _context.GoodsReceivingNotes.SingleOrDefaultAsync(
                x => x.Id == request.GoodsReceivingNoteId
            );

            if (goodsReceivingNote == null)
            {
                return new Result<List<GoodsReceivingDetailResponse>>(
                    new NotFoundException()
                );
            }

            var productIds = request.Products
                .Select(p => p.ProductId)
                .ToList();

            // Validate product id is unique
            var distinctProductIds = request.Products
                .Select(p => p.ProductId)
                .Distinct()
                .ToList();

            if (productIds.Count() != distinctProductIds.Count())
            {
                return new Result<List<GoodsReceivingDetailResponse>>(
                    new BadRequestException(
                        new ApiError("Mỗi sản phẩm chỉ được thêm vào phiếu nhập kho 1 lần")
                    )
                );
            }

            // Validate products exist
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            if (distinctProductIds.Count() != products.Count())
            {
                return new Result<List<GoodsReceivingDetailResponse>>(
                    new NotFoundException()
                );
            }

            var existedProducts = await _context.GoodsReceivingDetails
                .Where(x => x.GoodsReceivingNoteId == request.GoodsReceivingNoteId &&
                        productIds.Contains(x.ProductId))
                .ToListAsync();

            if (existedProducts.Count() > 0)
            {
                return new Result<List<GoodsReceivingDetailResponse>>(
                    new BadRequestException(
                        new ApiError("Có sản phẩm đã tồn tại ở phiếu nhập kho")
                    )
                );
            }

            var goodsReceivingDetails = _mapper.Map<List<GoodsReceivingDetail>>(request.Products);
            double sum = 0;
            foreach (var item in goodsReceivingDetails)
            {
                item.GoodsReceivingNoteId = request.GoodsReceivingNoteId;
                item.TotalPrice = item.Quantity * item.UnitPrice;
                sum += item.TotalPrice;
            }

            foreach (var p in products)
            {
                var update = request.Products
                    .FirstOrDefault(x => x.ProductId == p.Id);

                p.Quantity += update.Quantity;
            }

            var quantityLogs = request.Products
                .Select(x => new QuantityLog
                {
                    ProductId = x.ProductId
                })
                .ToList();

            foreach (var item in quantityLogs)
            {
                var update = products
                    .FirstOrDefault(x => x.Id == item.ProductId);

                item.InStock = update.Quantity;
            }

            goodsReceivingNote.TotalPrice += sum;

            _context.GoodsReceivingDetails.AddRange(goodsReceivingDetails);
            _context.Products.UpdateRange(products);
            _context.QuantityLogs.AddRange(quantityLogs);

            var created = await _context.SaveChangesAsync();

            if (created > 0)
            {
                return new Result<List<GoodsReceivingDetailResponse>>(
                    _mapper.Map<List<GoodsReceivingDetailResponse>>(goodsReceivingDetails)
                );
            }

            return new Result<List<GoodsReceivingDetailResponse>>(
                new BadRequestException(
                    new ApiError("Thêm sản phẩm vào phiếu nhập kho lỗi, xin thử lại"))
            );
        }
    }
}