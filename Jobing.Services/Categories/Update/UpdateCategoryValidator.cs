using FluentValidation;

namespace Services.Categories.Update;

public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x=>x.NameAz).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.NameRu).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.NameEn).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.NameTr).NotEmpty().WithMessage("Category name is required");
        RuleFor(x=>x.Icon).NotEmpty().WithMessage("Category icon is required");
        RuleFor(x=>x.IsActive).NotNull().WithMessage("Category is active is required");
        
    }
    
}