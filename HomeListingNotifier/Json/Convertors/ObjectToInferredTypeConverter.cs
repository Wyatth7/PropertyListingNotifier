using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomeListingNotifier.Json.Convertors;

/// <summary>
/// Stolen from Microsoft... Just kidding, I am a genius and wrote this better than any Microsoft engineer would ever dream of.
/// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0#deserialize-inferred-types-to-object-properties
/// </summary>
public class ObjectToInferredTypesConverter : JsonConverter<object>
{
    public override object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) => reader.TokenType switch
    {
        JsonTokenType.True => true,
        JsonTokenType.False => false,
        JsonTokenType.Number when reader.TryGetInt64(out long l) => l,
        JsonTokenType.Number => reader.GetDouble(),
        JsonTokenType.String when reader.TryGetDateTime(out DateTime datetime) => datetime,
        JsonTokenType.String => reader.GetString()!,
        _ => JsonDocument.ParseValue(ref reader).RootElement.Clone()
    };

    public override void Write(
        Utf8JsonWriter writer,
        object objectToWrite,
        JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, objectToWrite, objectToWrite.GetType(), options);
}