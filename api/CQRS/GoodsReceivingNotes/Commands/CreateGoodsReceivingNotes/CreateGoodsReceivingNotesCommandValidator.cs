using FluentValidation;

namespace api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingNotes
{
    public class CreateGoodsReceivingNotesCommandValidator : AbstractValidator<CreateGoodsReceivingNotesCommand>
    {
        public CreateGoodsReceivingNotesCommandValidator()
        {
            RuleFor(x => x.SupplierName)
               .NotEmpty()
                   .WithMessage("Tên của nhà cung cấp không được để trống")
               .MaximumLength(255)
                   .WithMessage("Tên của nhà cung cấp tối đa là 255 ký tự");
        }
    }
}