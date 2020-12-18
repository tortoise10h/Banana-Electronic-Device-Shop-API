using FluentValidation;

namespace api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingDetails
{
    public class CreateGoodsReceivingDetailsCommandValidator : AbstractValidator<CreateGoodsReceivingDetailsCommand>
    {
        public CreateGoodsReceivingDetailsCommandValidator()
        {
            RuleFor(x => x.GoodsReceivingNoteId)
               .NotNull()
               .GreaterThan(0)
                   .WithMessage("Id của phiếu nhập kho không hợp lệ");

            RuleFor(x => x.Products)
                .NotNull()
                    .WithMessage("Khi thêm sản phẩm cho phiếu nhập kho cần có ít nhất 1 sản phẩm")
                .Must(x => x != null && x.Count > 0)
                    .WithMessage("Khi thêm sản phẩm cho phiếu nhập kho cần có ít nhất 1 sản phẩm");

            RuleForEach(x => x.Products)
                .SetValidator(new ProductInGoodsReceivingDetailsValidator());
        }
    }
}