using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Products;
using api.Entities;
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

namespace api.CQRS.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommand : IRequest<Result<CategoryResponse>>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(
            DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CategoryResponse>> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            await _context.Categories.AddAsync(category);
            var created = await _context.SaveChangesAsync();
            if (created > 0)
            {
                return new Result<CategoryResponse>(
                    _mapper.Map<CategoryResponse>(category)
                );
            }

            return new Result<CategoryResponse>(
                new BadRequestException(new ApiError("Tạo danh mục sản phẩm xảy ra lỗi, xin thử lại"))
            );
        }
    }
}
