using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Products;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.CQRS.Products.Queries
{
    public class GetProductBySkuQuery : IRequest<Result<ProductResponse>>
    {
        public GetProductBySkuQuery(string sku)
        {
            SKU = sku;
        }
        public string SKU { get; set; }
    }

    public class GetProductBySkuHandler : IRequestHandler<GetProductBySkuQuery, Result<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetProductBySkuHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ProductResponse>> Handle(
            GetProductBySkuQuery request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // var product = await _context.Products
            //     .Include(p => p.ProductCategory)
            //     .Include(p => p.ProductUnits)
            //     .SingleOrDefaultAsync(
            //         p => p.SKU == request.SKU);

            // if (product == null)
            // {
            //     return new Result<ProductResponse>(
            //         new NotFoundException()
            //     );
            // }

            // return new Result<ProductResponse>(
            //     _mapper.Map<ProductResponse>(product)
            // );
        }
    }
}
