using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.CreateComboDetails
{
    public class CreateComboDetailCommandValidator : AbstractValidator<CreateComboDetailCommand>
    {
        public CreateComboDetailCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                    .WithMessage("Mã sản phẩm không hợp lệ");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                    .WithMessage("Số lượng của sản phẩm trong combo không được bé hơn 0");
        }
    }
}
