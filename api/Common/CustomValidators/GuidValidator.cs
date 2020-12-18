using System;
using FluentValidation;

namespace api.Common.CustomValidators
{
    public class GuidValidator : AbstractValidator<string>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .Must(ValidateGuid)
                    .WithMessage("Not a guid");
        }

        private bool ValidateGuid(string x)
        {
            return Guid.TryParse(x, out var result);
        }
    }
}