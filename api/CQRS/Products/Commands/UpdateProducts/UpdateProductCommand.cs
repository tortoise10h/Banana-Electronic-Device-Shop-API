using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using api.Contracts.V1.Exceptions;
using api.Common.Enums;
using api.Helpers;
using E = api.Entities;
using api.Contracts.V1.ResponseModels.Products;

namespace api.CQRS.Products.Commands.UpdateProducts
{
    public class UpdateProductCommand : IRequest<Result<ProductResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UpdateProductHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductResponse>> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(
                    p => p.Id == request.Id
                );
            if (product == null)
            {
                return new Result<ProductResponse>(
                    new NotFoundException()
                );
            }

            /** That's mean user want to update category of product */
            if (request.CategoryId != product.CategoryId)
            {
                var productCategory = await _context.Categories
                    .SingleOrDefaultAsync(pc => pc.Id == request.CategoryId);

                if (productCategory == null)
                {
                    return new Result<ProductResponse>(
                        new NotFoundException()
                    );
                }
            }

            /** Make sure SKU is unique */
            var existedProductWithSku = await _context.Products
                .SingleOrDefaultAsync(x => x.SKU == request.SKU &&
                    x.Id != product.Id);
            if (existedProductWithSku != null)
            {
                return new Result<ProductResponse>(
                    new BadRequestException(new ApiError("Mã SKU đã được sản phẩm khác sử dụng"))
                );
            }

            // TODO: Recalculate the price of all combos which contain this product ~_~

            _mapper.Map<UpdateProductCommand, E.Product>(request, product);

            _context.Products.Update(product);
            var updated = await _context.SaveChangesAsync();

            if (updated > 0)
            {
                return new Result<ProductResponse>(
                    _mapper.Map<ProductResponse>(product)
                );
            }

            return new Result<ProductResponse>(
                new BadRequestException(
                    new ApiError("Chỉnh sửa thông tin sản phẩm thất bại, xin thử lại"))
            );
        }
    }
}