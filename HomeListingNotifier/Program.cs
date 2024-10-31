using HomeListingNotifier;
using HomeListingNotifier.Mapping;

MapsterConfiguration.Configure();

using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(2000));

while (await timer.WaitForNextTickAsync())
{
    var queries = await QuerySerializer.GetQueries();
    var data = await ListingHttpClient.GetFromQuery(queries);

    await ListingProcessor.Process(data);
    
    // var shortenedValues = data
    //     .Select(l => new { UniqueListingsId = l.UniqueListingId, l.Location?.ListingAddressFull })
    //     .DistinctBy(l => l.UniqueListingsId)
    //     .ToArray();
    //
    // Console.WriteLine(shortenedValues.Length);
    //
    // Console.WriteLine($"Distinct values: {string.Join("\n,", shortenedValues.Select(l => $"{l.UniqueListingsId}:{l.ListingAddressFull}"))}");
}

Console.ReadLine();