using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Products;
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
using E = api.Entities;

namespace api.CQRS.Products.Commands.CreateProducts
{
    public class DeleteProductCommand : IRequest<Result<ProductResponse>>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Result<ProductResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IProductsService _productsService;

        public DeleteProductHandler(DataContext context, IMapper mapper, IProductsService productsService)
        {
            _context = context;
            _mapper = mapper;
            _productsService = productsService;
        }

        public async Task<Result<ProductResponse>> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            /** Make sure deleted product exist */
            var product = await _context.Products
                .SingleOrDefaultAsync(x => x.Id == request.Id);
            if (product == null)
            {
                return new Result<ProductResponse>(
                    new NotFoundException()
                );
            }

            /** Make sure there no relation when delete that product */
            var goodsDeliveryDetail = await _context.GoodsDeliveryDetails
                .FirstOrDefaultAsync(x => x.ProductId == request.Id);
            if (goodsDeliveryDetail != null)
            {
                return new Result<ProductResponse>(
                    new BadRequestException(
                        new ApiError("Không thể xoá sản phẩm vì còn tồn tại phiếu nhập kho cho sản phẩm này"))
                );
            }

            var comboDetail = await _context.ComboDetails
                .FirstOrDefaultAsync(x => x.ProductId == request.Id);
            if (comboDetail != null)
            {
                return new Result<ProductResponse>(
                    new BadRequestException(
                        new ApiError("Không thể xoá sản phẩm vì sản phẩm này còn tồn tại trong combo"))
                );
            }

            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(x => x.ProductId == request.Id);
            if (orderDetail != null)
            {
                return new Result<ProductResponse>(
                    new BadRequestException(
                        new ApiError("Không thể xoá sản phẩm vì còn tồn tại đơn hàng chứa sản phẩm này"))
                );
            }

            _context.Products.Remove(product);
            var deleted = await _context.SaveChangesAsync();
            return new Result<ProductResponse>(
                    _mapper.Map<ProductResponse>(product)
                );
        }
    }
}
