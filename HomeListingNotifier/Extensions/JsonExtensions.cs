using System.Text.Json;

namespace HomeListingNotifier.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object? value)
    {
        return value is null ? string.Empty : JsonSerializer.Serialize(value);
    }
}