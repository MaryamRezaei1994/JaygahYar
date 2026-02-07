using Microsoft.Extensions.Configuration;

namespace JaygahYar.Domain.Configuration;

/// <summary>
/// Central configuration holder (pattern copied from Survey.ConfigurationData).
/// </summary>
public static class ConfigurationData
{
    public static string DatabaseConnectionString { get; set; } = string.Empty;
    public static string RedisConnectionString { get; set; } = string.Empty;
    public static string RedisUsername { get; set; } = string.Empty;
    public static string RedisPassword { get; set; } = string.Empty;
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
                RedisConnectionString = "192.168.0.245:6379";
                RedisUsername = "iotuser";
                RedisPassword = "da0bd9b20c62de8ade2685d1a4c8c473ccc0586353ec5e1392ccc2da479143a3737b531add5980de";
                break;
            case "TEST":
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5434;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                RedisConnectionString = string.Empty;
                RedisUsername = string.Empty;
                RedisPassword = string.Empty;
                break;
            case "SQA":
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                RedisConnectionString = "192.168.1.75:6379";
                RedisUsername = string.Empty;
                RedisPassword = "da0bd9b20c62de8ade2685d1a4c8c473ccc0586353ec5e1392ccc2da479143a3737b531add5980de";
                break;
            default:
                DatabaseConnectionString =
                    "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=Abc@1234;Include Error Detail=true";
                break;
        }
#else
        DatabaseConnectionString = Environment.GetEnvironmentVariable("DB_PG_CONNECTION") ?? string.Empty;
        RedisConnectionString = Environment.GetEnvironmentVariable("DB_REDIS_CONNECTION") ?? string.Empty;
        RedisUsername = Environment.GetEnvironmentVariable("DB_REDIS_USERNAME") ?? string.Empty;
        RedisPassword = Environment.GetEnvironmentVariable("DB_REDIS_PASSWORD") ?? string.Empty;
#endif
    }
}

