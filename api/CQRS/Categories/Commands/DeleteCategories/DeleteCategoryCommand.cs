using api.Contracts.V1.ResponseModels.Categories;
using LanguageExt.Common;
using MediatR;

namespace api.CQRS.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommand : IRequest<Result<CategoryResponse>>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}