using HomeListingNotifier.Extensions;
using HomeListingNotifier.Model.Remax;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;
using PropertyType = Persistence.Entities.Types.PropertyType;

namespace HomeListingNotifier;

public static class ListingProcessor
{
    /// <summary>
    /// Filters, Writes to DB, and sends SMS based on inbound listing data
    /// </summary>
    /// <param name="listings">Array of listings to be processed</param>
    public static async Task Process(ListingData[] listings)
    {
        await using var listingDbContext = new ListingDbContext();

        try
        {
            var uniqueListItems = listings
                .Where(l => l.UniqueListingId is not null)
                .Select(l => l.UniqueListingId);
            
            // remove all listings from [] if present in DB.
            var existingValues = await listingDbContext.Listings
                .Where(l => uniqueListItems.Contains(l.ListingProviderId))
                .Select(l => l.ListingProviderId)
                .ToArrayAsync();

            var entities = listings
                .Where(l => !existingValues.Contains(l.UniqueListingId))
                .Adapt<Listing[]>()
                .Where(l => l.Properties
                    .Select(p => p.PropertyTypeId)
                    .Any(p => (PropertyType)p != PropertyType.Ignore))
                .ToArray();

            var failedResults = await SendMessages(entities);
            

            // do not save failed results, attempt sending on one of the next checks.
            entities = entities
                .Where(l => !failedResults.Contains(l.ListingProviderId))
                .ToArray();
            
            if (entities.Length == 0) return;
            
            listingDbContext.Listings.AddRange(entities);
            await listingDbContext.SaveChangesAsync();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        } 
    }

    private static async Task<string[]> SendMessages(Listing[] listings)
    {
        if (listings.Length == 0)
        {
            await TwilioSender.Send("No new listing were found in the last search. " +
                                    "To expand the search, update the filter settings in the request-location.json file.");
            return [];
        }

        var failedListingIds = new List<string>();
        foreach (var listing in listings)
        {
            if (listing.Properties.Count == 0) return [];
            var propertyDetails = listing.Properties.First().PropertyDetails!.GetPropertyDetailString();

            var message = $"{listing.GetListingUrl()} {propertyDetails}";

            var result = await TwilioSender.Send(message);

            if (!result)
                failedListingIds.Add(listing.ListingProviderId);
        }

        return failedListingIds.ToArray();
    }
}