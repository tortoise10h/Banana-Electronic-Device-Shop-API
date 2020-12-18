using FluentValidation;

namespace api.CQRS.Users.Commands.BanUsers
{
    public class BanUserCommandValidator : AbstractValidator<BanUserCommand>
    {
        public BanUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                    .WithMessage("Id user không hợp lệ");

            RuleFor(x => x.Status)
                .Must(x => x == true || x == false)
                    .WithMessage("Trạng thái không hợp lệ");
        }
    }
}