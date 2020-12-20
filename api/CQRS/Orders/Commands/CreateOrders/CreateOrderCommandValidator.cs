using FluentValidation;

namespace api.CQRS.Orders.Commands.CreateOrders
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.DeliveryAddress)
               .NotEmpty()
                   .WithMessage("Địa chỉ giao hàng không được để trống")
               .MaximumLength(255)
                   .WithMessage("Địa chỉ giao hàng tối đa là 255 ký tự");

            RuleFor(x => x.OrderDetails)
                .NotNull()
                    .WithMessage("Khi thêm sản phẩm cho đơn hàng cần có ít nhất 1 sản phẩm")
                .Must(x => x != null && x.Count > 0)
                    .WithMessage("Khi thêm sản phẩm cho đơn hàng cần có ít nhất 1 sản phẩm");

            RuleForEach(x => x.OrderDetails)
                .SetValidator(new ProductInOrderDetailsValidator());
        }
    }
}