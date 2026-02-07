using System.Text;
using System.Text.Json;
using StackExchange.Redis;

namespace JaygahYar.Application.Constants;

/// <summary>
/// مشابه Survey.CacheExtensions، ولی با JSON (ساده و بدون source-generator).
/// </summary>
public static class CacheExtensions
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public static byte[] JsonSerialize<T>(this T obj)
        => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj, JsonOptions));

    public static async Task<T?> GetJsonAsync<T>(this IDatabase database, string key)
    {
        var value = await database.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;
        return JsonSerializer.Deserialize<T>(value!, JsonOptions);
    }
}

