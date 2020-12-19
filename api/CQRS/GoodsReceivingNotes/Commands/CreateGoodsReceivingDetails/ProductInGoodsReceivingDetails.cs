using FluentValidation;

namespace api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingDetails
{
    public class ProductInGoodsReceivingDetails
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }

    public class ProductInGoodsReceivingDetailsValidator : AbstractValidator<ProductInGoodsReceivingDetails>
    {
        public ProductInGoodsReceivingDetailsValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                    .WithMessage("Id của sản phẩm không được để trống")
                .GreaterThan(0)
                    .WithMessage("Id của sản phẩm không hợp lệ");

            RuleFor(x => x.Quantity)
                .NotNull()
                    .WithMessage("Số lượng của sản phẩm trong phiếu nhập kho không được để trống");

            RuleFor(x => x.UnitPrice)
                .NotNull()
                    .WithMessage("Giá mua của sản phẩm không được để trống")
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Giá mua của sản phẩm phải lớn hơn hoặch bằng 0");
        }
    }
}