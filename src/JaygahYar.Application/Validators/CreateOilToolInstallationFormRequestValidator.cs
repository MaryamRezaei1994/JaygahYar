using FluentValidation;
using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Validators;

public class CreateOilToolInstallationFormRequestValidator : AbstractValidator<CreateOilToolInstallationFormRequest>
{
    public CreateOilToolInstallationFormRequestValidator()
    {
        RuleFor(x => x.FormNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.BuyerFullName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.StationName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Mobile).NotEmpty().MaximumLength(50);
        RuleFor(x => x.StationAddress).NotEmpty().MaximumLength(500);
        RuleFor(x => x.InstallationFormFilePath).NotEmpty().MaximumLength(500);
        RuleFor(x => x.PeymanegarTestFormFilePath).NotEmpty().MaximumLength(500);
    }
}
