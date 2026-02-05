using FluentValidation;
using JaygahYar.Application.Interfaces;
using JaygahYar.Application.Mapping;
using JaygahYar.Application.Services;
using JaygahYar.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace JaygahYar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddValidatorsFromAssemblyContaining<CreateStationRequestValidator>();

        services.AddScoped<IStationService, StationService>();
        services.AddScoped<IOilToolInstallationFormService, OilToolInstallationFormService>();
        services.AddScoped<ITankMonitoringInstallationFormService, TankMonitoringInstallationFormService>();
        services.AddScoped<IAfterSalesServiceReportService, AfterSalesServiceReportService>();
        services.AddScoped<IStage2DeliveryFormService, Stage2DeliveryFormService>();
        services.AddScoped<IStage3DeliveryFormService, Stage3DeliveryFormService>();

        return services;
    }
}
