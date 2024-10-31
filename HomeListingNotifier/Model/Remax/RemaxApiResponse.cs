using System.Text.Json.Serialization;

namespace HomeListingNotifier.Model.Remax;

public class RemaxApiResponse
{
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("results")] public ListingData[] Results { get; set; } = [];
}