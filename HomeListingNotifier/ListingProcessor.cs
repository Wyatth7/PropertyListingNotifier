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

        await using var transaction = await listingDbContext.Database.BeginTransactionAsync();
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

            if (entities.Length == 0) return;
            
            listingDbContext.Listings.AddRange(entities);
            await listingDbContext.SaveChangesAsync();

            // await SendMessages(entities);

            

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await transaction.RollbackAsync();
        } 

    }

    private static async Task SendMessages(Listing[] listings)
    {
        var sender = new TwilioSender();
        if (listings.Length == 0)
        {
            await sender.Send("No new listing were found in the last search. " +
                              "To expand the search, update the filter settings in the request-location.json file.");
            return;
        }
        
        // foreach (var listing in listings)
        // {
        //     var 
        // }
        
        var listing = listings.First();
        
        if (listing.Properties.Count == 0) return;
        var propertyDetails = listing.Properties.First().PropertyDetails!.GetPropertyDetailString();

        var message = $"{listing.GetListingUrl()} {propertyDetails}";

        await sender.Send(message);
    }

    private static void LogStats(ListingData[] listings)
    {
        
    }
}