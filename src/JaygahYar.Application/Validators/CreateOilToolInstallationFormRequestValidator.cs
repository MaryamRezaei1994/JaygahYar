using FluentValidation;
using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Validators;

public class CreateOilToolInstallationFormRequestValidator : AbstractValidator<CreateOilToolInstallationFormRequest>
{
    public CreateOilToolInstallationFormRequestValidator()
    {
        RuleFor(x => x.FormNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.BuyerName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.StationId).NotEmpty();
    }
}
