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
    public class GetProductByIdQuery : IRequest<Result<ProductResponse>>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetProductByIdHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ProductResponse>> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.QuantityLogs)
                .SingleOrDefaultAsync(
                    p => p.Id == request.Id);

            if (product == null)
            {
                return new Result<ProductResponse>(
                    new NotFoundException()
                );
            }

            return new Result<ProductResponse>(
                _mapper.Map<ProductResponse>(product)
            );
        }
    }
}
