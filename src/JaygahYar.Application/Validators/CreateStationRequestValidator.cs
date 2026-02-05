using FluentValidation;
using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Validators;

public class CreateStationRequestValidator : AbstractValidator<CreateStationRequest>
{
    public CreateStationRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(500);
        RuleFor(x => x.GasolineTankCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.DieselTankCount).GreaterThanOrEqualTo(0);
    }
}
