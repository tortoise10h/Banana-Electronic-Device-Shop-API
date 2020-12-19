using api.CQRS.Combos.Commands.CreateComboDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.CreateCombos
{
    public class CreateComboCommandValidator : AbstractValidator<CreateComboCommand>
    {
        public CreateComboCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Tên của combo không được để trống")
                .MaximumLength(255)
                    .WithMessage("Tên của combo tối đa là 255 ký tự");

            RuleFor(x => x.DiscountPercentage)
                .Must(x => x >= 0 && x <= 100)
                    .WithMessage("% Giảm giá chỉ được phép nằm trong khoảng 0 -> 100%");

            RuleFor(x => x.ComboDetails)
                .Must(x => x != null && x.GroupBy(x => x.ProductId)
                    .Select(x => x.First())
                        .Count() >= 2)
                .WithMessage(
                    "Phải có ít nhất 2 sản phẩm khi tạo combo và sản phẩm trong combo không được trùng nhau");


            RuleForEach(x => x.ComboDetails)
                .SetValidator(new CreateComboDetailCommandValidator());
        }
    }
}
