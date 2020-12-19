using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.UpdateComboDetails
{
    public class UpdateComboDetailCommandValidator : AbstractValidator<UpdateComboDetailCommand>
    {
        public UpdateComboDetailCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                    .WithMessage("Số lượng của sản phẩm trong combo không được bé hơn 1");
        }
    }
}
