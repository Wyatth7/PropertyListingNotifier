using System.Globalization;
using System.Text.Json;

namespace HomeListingNotifier.Model.Remax;

// usa?
// pageNumber=1
// &size=24
// &sortKey=1
// &sortDirection=1
// &features%5Bcity%5D=&features%5BstateOrProvince%5D=ga&features%5BuiTransactionType%5D=Sale&features%5BmaxPrice%5D=450000

// usa?pageNumber=1&size=24&sortKey=1&sortDirection=1&features%5Bcity%5D=&features%5BstateOrProvince%5D=ga&features%5BuiTransactionType%5D=Sale&features%5BmaxPrice%5D=450000
public class RemaxFilter
{
    public string Country { get; set; } = string.Empty;

    public int Size { get; set; }

    public int SortKey { get; set; }

    public int PageNumber { get; set; }

    public int SortDirection { get; set; }

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string UiTransactionType { get; set; } = string.Empty;

    public string UiPropertyType { get; set; } = string.Empty;
    
    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }

    public float MinSqft { get; set; }

    public int MinYearBuilt { get; set; }
    
    public string AsQueryString()
    {
        var queryDictionary = new Dictionary<string, string>()
        {
            {"pageNumber", PageNumber.ToString()},
            {"size", Size.ToString()},
            {"sortKey", SortKey.ToString()},
            {"sortDirection", SortDirection.ToString()},
            {GetFeature(nameof(City)), City},
            {GetFeature(nameof(State)), State},
            {GetFeature(nameof(UiTransactionType)), UiTransactionType},
            {GetFeature(nameof(MinPrice)), MinPrice.ToString(CultureInfo.InvariantCulture)},
            {GetFeature(nameof(MaxPrice)), MaxPrice.ToString(CultureInfo.InvariantCulture)},
            {GetFeature(nameof(UiPropertyType)), UiPropertyType},
            {GetFeature(nameof(MinSqft)), MinSqft.ToString(CultureInfo.InvariantCulture)},
            {GetFeature(nameof(MinYearBuilt)), MinYearBuilt.ToString()}
        };

        return $"{Country}?" + string.Join("&", queryDictionary.Select(q => $"{q.Key}={q.Value}"));
    }

    private static string GetFeature(string propertyName)
    {
        var camelCaseName = JsonNamingPolicy.CamelCase.ConvertName(propertyName);
        return $"features[{camelCaseName}]";
    }
}