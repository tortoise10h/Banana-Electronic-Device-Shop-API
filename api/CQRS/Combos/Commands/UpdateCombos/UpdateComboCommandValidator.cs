using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.UpdateCombos
{
    public class UpdateComboCommandValidator : AbstractValidator<UpdateComboCommand>
    {
        public UpdateComboCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Tên của danh mục không được để trống")
                .MaximumLength(255)
                    .WithMessage("Tên của danh mục tối đa là 255 ký tự");

            RuleFor(x => x.DiscountPercentage)
                .Must(x => x >= 0 && x <= 100)
                    .WithMessage("% giảm giá chỉ được phép nằm trong khoảng 0 -> 100%");
        }
    }
}
