using JaygahYar.Domain.Interfaces;
using JaygahYar.Domain.Configuration;
using JaygahYar.Infrastructure.Persistence;
using JaygahYar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using JaygahYar.Application.Interfaces;
using JaygahYar.Application.Services;

namespace JaygahYar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                ConfigurationData.DatabaseConnectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<IOilToolInstallationFormRepository, OilToolInstallationFormRepository>();
        services.AddScoped<ITankMonitoringInstallationFormRepository, TankMonitoringInstallationFormRepository>();
        services.AddScoped<IAfterSalesServiceReportRepository, AfterSalesServiceReportRepository>();
        services.AddScoped<IStage2DeliveryFormRepository, Stage2DeliveryFormRepository>();
        services.AddScoped<IStage3DeliveryFormRepository, Stage3DeliveryFormRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICacheProvider, CacheProvider>();

        return services;
    }
}
