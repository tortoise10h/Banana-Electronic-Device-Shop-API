using api.CQRS.Combos.Commands.CreateComboDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.BulkCreateComboDetails
{
    public class BulkBulkCreateComboDetailCommandValidator : AbstractValidator<BulkCreateComboDetailCommand>
    {
        public BulkBulkCreateComboDetailCommandValidator()
        {
            RuleFor(x => x.ComboDetails)
                .Must(x => x != null && x.GroupBy(x => x.ProductId)
                    .Select(x => x.First())
                        .Count() > 0)
                .WithMessage(
                    "Phải có ít nhất một sản phẩm khi thêm vào combo và các sản phẩm được thêm vào không trùng nhau");

            RuleForEach(x => x.ComboDetails)
                .SetValidator(new CreateComboDetailCommandValidator());
        }
    }
}
