using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Products;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using E = api.Entities;

namespace src.CQRS.QuantityLogs.Queries
{
    public class StatisticQuantityLogOfProductQuery : PaginationQuery, IRequest<Result<PagedResponse<QuantityLogResponse>>>
    {
        public int ProductId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class StatisticQuantityLogOfProductHandler : IRequestHandler<StatisticQuantityLogOfProductQuery, Result<PagedResponse<QuantityLogResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginationHelpers _paginationHelper;

        public StatisticQuantityLogOfProductHandler(DataContext context, IMapper mapper, IPaginationHelpers paginationHelper)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
        }

        public async Task<Result<PagedResponse<QuantityLogResponse>>> Handle(
            StatisticQuantityLogOfProductQuery query,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(x => x.Id == query.ProductId);
            if (product == null)
            {
                throw new NotFoundException();
            }

            var queryable = _context.QuantityLogs.AsQueryable();
            queryable = queryable.AsNoTracking();
            queryable = queryable
                .Where(x => x.ProductId == query.ProductId)
                .Include(x => x.Product);

            if (query.FromDate != null)
            {
                queryable = queryable.Where(
                    x => x.CreatedAt >= query.FromDate
                );
            }

            if (query.ToDate != null)
            {
                queryable = queryable.Where(
                    x => x.CreatedAt <= query.ToDate
                );
            }

            int skip = (query.Page - 1) * query.Limit;

            var entities = await queryable
                .Skip(skip)
                .Take(query.Limit)
                .ToListAsync();
            var totalEntities = await queryable.CountAsync();

            var result = _paginationHelper
                .CreatePaginatedResponse<E.QuantityLog, QuantityLogResponse>(
                    query, entities, totalEntities);

            return result;
        }
    }
}