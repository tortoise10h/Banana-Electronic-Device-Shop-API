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
    public class CreateProductCommand : IRequest<Result<ProductResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultUnit { get; set; }
        public double? PurchasePrice { get; set; }
        public double Price { get; set; }
        public int ProductCategoryId { get; set; }
        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
    }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<ProductResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IProductsService _productsService;

        public CreateProductHandler(DataContext context, IMapper mapper, IProductsService productsService)
        {
            _context = context;
            _mapper = mapper;
            _productsService = productsService;
        }

        public async Task<Result<ProductResponse>> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // /** Make sure the category of product is existed */
            // var productCategory = await _context.ProductCategories
            //     .SingleOrDefaultAsync(
            //         pc => pc.Id == request.ProductCategoryId);
            // if (productCategory == null)
            // {
            //     return new Result<ProductResponse>(
            //         new NotFoundException()
            //     );
            // }

            // var product = _mapper.Map<E.Product>(request);
            // product.Status = ProductStatus.Available;

            // await _context.Products.AddAsync(product);
            // var created = await _context.SaveChangesAsync();
            // if (created > 0)
            // {
            //     /** Generate SKU for product */
            //     product.SKU = _productsService.GenerateProductSKU(
            //         productCategory.Name, product.Id);
            //     _context.Products.Update(product);
            //     await _context.SaveChangesAsync();

            //     return new Result<ProductResponse>(
            //         _mapper.Map<ProductResponse>(product)
            //     );
            // }

            // return new Result<ProductResponse>(
            //     new BadRequestException(new ApiError("Tạo sản phẩm thất bại, xin thử lại"))
            // );
        }
    }
}
