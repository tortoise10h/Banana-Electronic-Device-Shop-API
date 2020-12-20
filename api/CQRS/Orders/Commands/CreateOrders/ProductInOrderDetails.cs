using FluentValidation;

namespace api.CQRS.Orders.Commands.CreateOrders
{
    public class ProductInOrderDetails
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? ComboId { get; set; }
    }

    public class ProductInOrderDetailsValidator : AbstractValidator<ProductInOrderDetails>
    {
        public ProductInOrderDetailsValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                    .WithMessage("Id của sản phẩm không được để trống")
                .GreaterThan(0)
                    .WithMessage("Id của sản phẩm không hợp lệ");

            RuleFor(x => x.Quantity)
                .NotNull()
                    .WithMessage("Số lượng của sản phẩm trong đơn hàng không được để trống");
        }
    }
}