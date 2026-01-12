using FluentValidation;

namespace Services.Categories.Create;

public class CreateCategoryRequestValidator:AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x=>x.NameAz).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.NameRu).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.NameEn).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.NameTr).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.Icon).NotEmpty().WithMessage("Category icon is required");
    }
}