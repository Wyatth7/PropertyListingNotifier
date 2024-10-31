using HomeListingNotifier;
using HomeListingNotifier.Mapping;

MapsterConfiguration.Configure();

using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(2000));

while (await timer.WaitForNextTickAsync())
{
    var queries = await QuerySerializer.GetQueries();
    var data = await ListingHttpClient.GetFromQuery(queries);

    await ListingProcessor.Process(data);
}

Console.ReadLine();