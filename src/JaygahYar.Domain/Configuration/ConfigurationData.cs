using Microsoft.Extensions.Configuration;

namespace JaygahYar.Domain.Configuration;

/// <summary>
/// Central configuration holder (pattern copied from Survey.ConfigurationData).
/// </summary>
public static class ConfigurationData
{
    public static string DatabaseConnectionString { get; set; } = string.Empty;
    public static string Version { get; set; } = "v1";

    public static void Config(IConfiguration config)
    {
#if DEBUG
        var currentConfig = config.GetSection("Environment").Value?.Trim().ToUpper() ?? "DEVELOPMENT";

        switch (currentConfig)
        {
            case "DEVELOPMENT":
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                break;
            case "TEST":
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5434;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                break;
            case "SQA":
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                break;
            default:
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                break;
        }
#else
        DatabaseConnectionString = Environment.GetEnvironmentVariable("DB_PG_CONNECTION") ?? string.Empty;
#endif
    }
}

