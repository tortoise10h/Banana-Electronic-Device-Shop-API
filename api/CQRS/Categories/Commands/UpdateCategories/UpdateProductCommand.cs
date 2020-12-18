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
using api.Contracts.V1.ResponseModels.Products;
using api.Contracts.V1.ResponseModels.Categories;
using api.Entities;

namespace api.CQRS.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommand : IRequest<Result<CategoryResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Result<CategoryResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CategoryResponse>> Handle(
            UpdateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .SingleOrDefaultAsync(
                    x => x.Id == request.Id
                );
            if (category == null)
            {
                return new Result<CategoryResponse>(
                    new NotFoundException()
                );
            }

            _mapper.Map<UpdateCategoryCommand, Category>(request, category);

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return new Result<CategoryResponse>(
                    _mapper.Map<CategoryResponse>(category)
                );
        }
    }
}