using System.Text.Json;
using HomeListingNotifier.Model.Remax;
using Persistence.Entities;

namespace HomeListingNotifier.Extensions;

public static class RemaxExtensions
{
    private const string BaseListingUrl = "https://www.remax.com";
    
    public static string GetBaseImageUrl(this RemaxImages[]? images)
    {
        if (images is null) return string.Empty;

        return images.FirstOrDefault()?.ComputedUrl ?? string.Empty;
    }

    public static string GetListingUrl(this Listing listing)
    {
        var listingResource = JsonSerializer.Deserialize<ListingResource>(listing.Resource!.Data);
        var address = listing.Properties.First().Address;

        if (address is null || listingResource is null) return string.Empty;

        var addressFull = address.ListingAddressFull.Replace(",", "").Replace(' ', '-');
        
        var splitIds = string.Join('/', listingResource.UniqueListingId.Split("-"));

        return $"{BaseListingUrl}/{address.State}/{address.City}/home-details/{addressFull}/{listingResource.Upi}/{splitIds}";
    }

    public static string GetPropertyDetailString(this PropertyDetails details)
    {
        return $"Price: {details.Price:C}, Price Change: {details.PriceChange:C}, " +
               $"Bedrooms: {details.Bedrooms}, Bathrooms: {details.Bathrooms}, " +
               $"Sqft: {details.LivingArea:0.00}, Acres: {details.LotSizeAcres:0.00}, " +
               $"Built: {details.YearBuilt}";
    }
}