using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Products.Commands.CreateProducts
{
    public class CreateProductCommadValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommadValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Tên của sản phẩm không được để trống")
                .MaximumLength(255)
                    .WithMessage("Tên của sản phẩm tối đa là 255 ký tự");

            RuleFor(x => x.DefaultUnit)
                .NotEmpty()
                    .WithMessage("Đơn vị tính không được để trống")
                .MaximumLength(255)
                    .WithMessage("Đơn vị tính tối đa là 255 ký tự");

            RuleFor(x => x.Price)
                .NotNull()
                    .WithMessage("Giá bán của sản phẩm không được để trống")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Giá bán của sản phẩm không nhỏ hơn 0 đồng");

            RuleFor(x => x.ProductCategoryId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id của danh mục sản phẩm không hợp lệ");
        }
    }
}
