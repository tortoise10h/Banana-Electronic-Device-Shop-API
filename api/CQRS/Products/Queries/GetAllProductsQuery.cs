using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Products;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using E = api.Entities;

namespace src.CQRS.Products.Queries
{
    public class GetAllProductsQuery : PaginationQuery, IRequest<Result<PagedResponse<ProductResponse>>>
    {

    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Result<PagedResponse<ProductResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginationHelpers _paginationHelper;

        public GetAllProductsHandler(DataContext context, IMapper mapper, IPaginationHelpers paginationHelper)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
        }

        public async Task<Result<PagedResponse<ProductResponse>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var queryable = _context.Products.AsQueryable();
            queryable = queryable
                .Include(p => p.Category);
            var result = await _paginationHelper.Paginate<E.Product, ProductResponse>(
                queryable, query
            );

            return result;
        }
    }
}