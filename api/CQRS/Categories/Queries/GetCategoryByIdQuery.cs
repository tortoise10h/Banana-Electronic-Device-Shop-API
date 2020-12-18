using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Categories;
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
    public class GetCategoryByIdQuery : IRequest<Result<CategoryResponse>>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetCategoryByIdHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<CategoryResponse>> Handle(
            GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .SingleOrDefaultAsync(
                    x => x.Id == request.Id);

            if (category == null)
            {
                return new Result<CategoryResponse>(
                    new NotFoundException()
                );
            }

            return new Result<CategoryResponse>(
                _mapper.Map<CategoryResponse>(category)
            );
        }
    }
}
