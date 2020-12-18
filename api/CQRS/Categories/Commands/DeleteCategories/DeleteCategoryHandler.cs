using System.Threading;
using System.Threading.Tasks;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Categories;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.CQRS.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Result<CategoryResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DeleteCategoryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CategoryResponse>> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (category == null)
            {
                throw new NotFoundException("Danh mục sản phẩm không tồn tại");
            }

            var productOfCategory = await _context.Products
                .FirstOrDefaultAsync(p => p.CategoryId == request.Id);
            if (productOfCategory != null)
            {
                throw new BadRequestException(
                    new ApiError("Chỉ có thể xóa danh mục không chứa sản phẩm"));
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return new Result<CategoryResponse>(
                _mapper.Map<CategoryResponse>(category)
            );
        }
    }
}