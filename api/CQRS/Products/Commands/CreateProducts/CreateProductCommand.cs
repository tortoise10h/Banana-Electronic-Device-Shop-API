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
        public string Unit { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
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
            /** Make sure the category of product is existed */
            var category = await _context.Categories
                .SingleOrDefaultAsync(
                    x => x.Id == request.CategoryId);
            if (category == null)
            {
                return new Result<ProductResponse>(
                    new NotFoundException()
                );
            }

            /** Make sure SKU is unique */
            var existedProductWithSku = await _context.Products
                .SingleOrDefaultAsync(x => x.SKU == request.SKU);
            if (existedProductWithSku != null)
            {
                return new Result<ProductResponse>(
                    new BadRequestException(new ApiError("Mã SKU của sản phẩm đã tồn tại"))
                );
            }

            var product = _mapper.Map<E.Product>(request);

            await _context.Products.AddAsync(product);
            var created = await _context.SaveChangesAsync();
            if (created > 0)
            {
                return new Result<ProductResponse>(
                    _mapper.Map<ProductResponse>(product)
                );
            }

            return new Result<ProductResponse>(
                new BadRequestException(new ApiError("Tạo sản phẩm thất bại, xin thử lại"))
            );
        }
    }
}
