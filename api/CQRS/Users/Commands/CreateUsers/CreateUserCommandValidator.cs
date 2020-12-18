using api.Common.Enums;
using FluentValidation;

namespace api.CQRS.Users.Commands.CreateUsers
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .Must(x => x == RoleName.Boss || x == RoleName.Sale ||
                        x == RoleName.WarehouseKeeper || x == RoleName.WarehouseKeeperManager || x == RoleName.Admin)
                        .WithMessage("Chức vụ không hợp lệ");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                    .WithMessage("Mật khẩu không hợp lệ");

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty()
                .Matches(x => x.Password)
                    .WithMessage("Mật khẩu không trùng khớp");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(255)
                    .WithMessage("Tên không hợp lệ");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(255)
                    .WithMessage("Tên không hợp lệ");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"[0-9]")
                    .WithMessage("Số điện thoại chỉ cho phép chứa số")
                .Length(10);
        }
    }
}