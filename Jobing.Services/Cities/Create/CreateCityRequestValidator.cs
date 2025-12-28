using FluentValidation;
using Repositories.Cities;

namespace Services.Cities.Create;

public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
{
    private readonly ICityInterface _cityRepository;

    public CreateCityRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("City name is required")
            .MinimumLength(3)
            .WithMessage("City name cannot be less than 3 characters")
            .MaximumLength(100)
            .WithMessage("City name cannot be more than 100 characters")
            .NotNull().WithMessage("City name cannot be null");
        // .MustAsync(MustUniqueNameAsync).WithMessage("City name must be unique")
    }
    //
    // private async Task<bool> MustUniqueNameAsync(string name, CancellationToken cancellationToken)
    // {
    //     return !await _cityRepository.Where(x=>x.Name == name).AnyAsync(cancellationToken);
    // }
}