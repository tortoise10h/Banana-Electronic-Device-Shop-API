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
        public string DefaultUnit { get; set; }
        public double PurchasePrice { get; set; }
        public double Price { get; set; }
        public ProductStatus Status { get; set; }
        public int ProductCategoryId { get; set; }
        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
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

        public async Task<Result<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // var product = await _context.Products
            //     .SingleOrDefaultAsync(
            //         p => p.Id == request.Id
            //     );
            // if (product == null)
            // {
            //     return new Result<ProductResponse>(
            //         new NotFoundException()
            //     );
            // }

            // /** That's mean user want to update category of product */
            // if (request.ProductCategoryId != product.ProductCategoryId)
            // {
            //     var productCategory = await _context.ProductCategories
            //         .SingleOrDefaultAsync(pc => pc.Id == request.ProductCategoryId);

            //     if (productCategory == null)
            //     {
            //         return new Result<ProductResponse>(
            //             new NotFoundException()
            //         );
            //     }
            // }

            // _mapper.Map<UpdateProductCommand, E.Product>(request, product);

            // _context.Products.Update(product);
            // var updated = await _context.SaveChangesAsync();

            // if (updated > 0)
            // {
            //     return new Result<ProductResponse>(
            //         _mapper.Map<ProductResponse>(product)
            //     );
            // }

            // return new Result<ProductResponse>(
            //     new BadRequestException(
            //         new ApiError("Chỉnh sửa thông tin sản phẩm thất bại, xin thử lại"))
            // );
        }
    }
}