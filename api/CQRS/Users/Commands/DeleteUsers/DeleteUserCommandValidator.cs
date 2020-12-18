using FluentValidation;

namespace api.CQRS.Users.Commands.DeleteUsers
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                    .WithMessage("Id user không hợp lệ");
        }
    }
}