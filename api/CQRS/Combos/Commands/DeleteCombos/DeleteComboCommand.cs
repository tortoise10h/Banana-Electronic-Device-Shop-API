using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Combos;
using LanguageExt.Common;
using MediatR;

namespace api.CQRS.Combos.Commands.DeleteCombos
{
    public class DeleteComboCommand : IRequest<Result<ComboResponse>>
    {
        public DeleteComboCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}