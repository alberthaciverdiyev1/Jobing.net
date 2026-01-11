using FluentValidation;

namespace Services.Cities.Update;

public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
{
    public UpdateCityRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("City name is required")
            .MinimumLength(3)
            .WithMessage("City name cannot be less than 3 characters")
            .MaximumLength(100)
            .WithMessage("City name cannot be more than 100 characters")
            .NotNull().WithMessage("City name cannot be null");
    }
}