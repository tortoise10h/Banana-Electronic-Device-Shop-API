using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Tên của danh mục sản phẩm không được để trống")
                .MaximumLength(255)
                    .WithMessage("Tên của danh mục sản phẩm tối đa là 255 ký tự");
        }
    }
}
