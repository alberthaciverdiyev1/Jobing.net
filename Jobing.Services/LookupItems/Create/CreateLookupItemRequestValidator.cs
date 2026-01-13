using FluentValidation;

namespace Services.LookupItems.Create;

public class CreateLookupItemRequestValidator : AbstractValidator<CreateLookupItemRequest>
{
    public CreateLookupItemRequestValidator()
    {
        RuleFor(x => x.Name)
            .Must(names => names != null && names.ContainsKey("az") && !string.IsNullOrWhiteSpace(names["az"]))
            .Must(names => names != null && names.ContainsKey("en") && !string.IsNullOrWhiteSpace(names["en"]))
            .Must(names => names != null && names.ContainsKey("tr") && !string.IsNullOrWhiteSpace(names["tr"]))
            .Must(names => names != null && names.ContainsKey("ru") && !string.IsNullOrWhiteSpace(names["ru"]))
            .WithMessage("Name (az,ru,en,tr) is required");
        
        RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        RuleFor(x => x.Group).NotEmpty().WithMessage("Group is required");
    }
}