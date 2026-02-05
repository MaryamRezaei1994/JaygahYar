using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using JaygahYar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JaygahYar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("JaygahYarDb"));
        }

        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<IOilToolInstallationFormRepository, OilToolInstallationFormRepository>();
        services.AddScoped<ITankMonitoringInstallationFormRepository, TankMonitoringInstallationFormRepository>();
        services.AddScoped<IAfterSalesServiceReportRepository, AfterSalesServiceReportRepository>();
        services.AddScoped<IStage2DeliveryFormRepository, Stage2DeliveryFormRepository>();
        services.AddScoped<IStage3DeliveryFormRepository, Stage3DeliveryFormRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
