using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JaygahYar.Domain.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace JaygahYar.Infrastructure.Persistence;

/// <summary>
/// فقط برای ابزارهای EF در زمان طراحی (Add Migration, Update-Database) استفاده می‌شود.
/// در زمان اجرای برنامه از DI استفاده می‌شود.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var basePaths = new[]
        {
            Path.Combine(Directory.GetCurrentDirectory(), "..", "JaygahYar.WebAPI"),
            Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "JaygahYar.WebAPI"),
            Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "JaygahYar.WebAPI")
        };

        var builder = new ConfigurationBuilder();
        foreach (var basePath in basePaths)
        {
            var fullPath = Path.GetFullPath(basePath);
            if (File.Exists(Path.Combine(fullPath, "appsettings.json")))
            {
                builder.SetBasePath(fullPath)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile("appsettings.Development.json", optional: true);
                break;
            }
        }

        var configuration = builder.Build();
        ConfigurationData.Config(configuration);
        var connectionString = ConfigurationData.DatabaseConnectionString;

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
