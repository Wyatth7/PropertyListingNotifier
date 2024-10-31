using System.Net.Http.Json;
using System.Text.Json;
using HomeListingNotifier.Json.Convertors;
using HomeListingNotifier.Model;
using HomeListingNotifier.Model.Remax;
using Mapster;

namespace HomeListingNotifier;

public static class ListingHttpClient
{
    private static readonly HttpClient Client = new();

    private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true };

    static ListingHttpClient()
    {
        Options.Converters.Add(new ObjectToInferredTypesConverter());
    }
    
    public static async Task<ListingData[]> GetFromQuery(HousingQuery[] queries)
    {
        var storedListingData = (await RemaxTestingFileDataStorage.Get()).ToList();

        if (storedListingData.Count > 0) return storedListingData.ToArray();
        
        foreach (var query in queries)
        {
            var response = await Client.PostAsJsonAsync(query.OutboundUrl + query.RequestFilter.AsQueryString(), query.Body);

            var body = await response.Content.ReadAsStringAsync();
            
            var data = JsonSerializer.Deserialize<RemaxApiResponse>(body, Options);

            if (data is not null)
                storedListingData.AddRange(data.Results);
        }

        await RemaxTestingFileDataStorage.Set(storedListingData);
        return storedListingData.ToArray();
    }
}