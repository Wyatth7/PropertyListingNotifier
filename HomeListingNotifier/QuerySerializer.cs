using System.Text;
using System.Text.Json;
using HomeListingNotifier.Model;

namespace HomeListingNotifier;

public static class QuerySerializer
{
    public static async Task<HousingQuery[]> GetQueries()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "requestlocation.json");

        using var streamReader = new StreamReader(path, Encoding.UTF8);
        var fileData = await streamReader.ReadToEndAsync();

        return JsonSerializer.Deserialize<HousingQuery[]>(fileData) ?? [];
    }
}