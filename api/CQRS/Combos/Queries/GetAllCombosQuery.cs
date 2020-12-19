using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Combos;
using api.Contracts.V1.ResponseModels.Products;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Combos.Queries
{
    public class GetAllCombosQuery : PaginationQuery, IRequest<Result<PagedResponse<ComboResponse>>>
    {

    }

    public class GetAllCombosHandler : IRequestHandler<GetAllCombosQuery, Result<PagedResponse<ComboResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginationHelpers _paginationHelper;

        public GetAllCombosHandler(
            DataContext context,
            IMapper mapper,
            IPaginationHelpers paginationHelper)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
        }

        public async Task<Result<PagedResponse<ComboResponse>>> Handle(
            GetAllCombosQuery query,
            CancellationToken cancellationToken)
        {
            var queryable = _context.Combos.AsQueryable();
            queryable = queryable
                .Include(x => x.ComboDetails)
                    .ThenInclude(cd => cd.Product);
            var result = await _paginationHelper.Paginate<Combo, ComboResponse>(
                queryable, query
            );

            return result;
        }
    }
}