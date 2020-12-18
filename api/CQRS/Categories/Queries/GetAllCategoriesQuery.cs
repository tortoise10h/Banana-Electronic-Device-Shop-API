using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Products;
using api.Entities;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Categories.Queries
{
    public class GetAllCategoriesQuery : PaginationQuery, IRequest<Result<PagedResponse<CategoryResponse>>>
    {

    }

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, Result<PagedResponse<CategoryResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginationHelpers _paginationHelper;

        public GetAllCategoriesHandler(
            DataContext context,
            IMapper mapper,
            IPaginationHelpers paginationHelper)
        {
            _context = context;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
        }

        public async Task<Result<PagedResponse<CategoryResponse>>> Handle(
            GetAllCategoriesQuery query,
            CancellationToken cancellationToken)
        {
            var queryable = _context.Categories.AsQueryable();
            var result = await _paginationHelper.Paginate<Category, CategoryResponse>(
                queryable, query
            );

            return result;
        }
    }
}