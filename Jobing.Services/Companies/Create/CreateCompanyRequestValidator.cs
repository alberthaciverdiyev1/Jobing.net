using FluentValidation;
using Services.Enums;

namespace Services.Companies.Create;

public class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
{
    public CreateCompanyRequestValidator()
    {
        RuleFor(x => x.Name)
            .Must(names => names != null && names.ContainsKey("az") && !string.IsNullOrWhiteSpace(names["az"]))
            .WithMessage("Name in Azerbaijani (az) is required");

        RuleFor(x => x.Description)
            .Must(desc => desc != null && desc.ContainsKey("az") && !string.IsNullOrWhiteSpace(desc["az"]))
            .WithMessage("Description in Azerbaijani (az) is required");

        RuleFor(x => x.Logo)
            .Must(file => file == null || AllowedImageFormats.ContentTypes.Contains(file.ContentType))
            .WithMessage($"Logo must be a valid image: {string.Join(", ", AllowedImageFormats.ContentTypes)}");
    }
}