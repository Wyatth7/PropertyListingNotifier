using HomeListingNotifier.Mapping.Remax;
using Mapster;

namespace HomeListingNotifier.Mapping;

public static class MapsterConfiguration
{
    public static void Configure()
    {
        var config = TypeAdapterConfig.GlobalSettings;

        new ListingDataRegister().Register(config);
    }
}