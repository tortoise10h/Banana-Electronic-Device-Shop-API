using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.CQRS.Categories.Commands.CreateCategories
{
    public class CreateProductCommadValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateProductCommadValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Tên của danh mục không được để trống")
                .MaximumLength(255)
                    .WithMessage("Tên của danh mục tối đa là 255 ký tự");
        }
    }
}
