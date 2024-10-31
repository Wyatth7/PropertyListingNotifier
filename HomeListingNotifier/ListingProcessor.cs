using HomeListingNotifier.Model.Remax;
using Mapster;
using MapsterMapper;
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

        /*
         * Create processing class that:
         *
         * 1) Filters out all sent properties
         * 2) Inserts all new properties into DB
         * 3) Sends SMS messages with details on property info.
         */

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
                    .Any(p => (PropertyType)p != PropertyType.Ignore));

            listingDbContext.Listings.AddRange(entities);
            await listingDbContext.SaveChangesAsync();

            // send SMS with property details and title image. (maybe send messages before saving to DB?)

            // log some meta-data related to the records sent & filtered out count

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await transaction.RollbackAsync();
        } 

    }

    private static void LogStats(ListingData[] listings)
    {
        
    }
}