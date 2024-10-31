namespace HomeListingNotifier.Model.Remax;

public class RemaxAddress
{
    public TimeZone Timezone { get; set; } = new();

    public RemaxAddress AddressComponents { get; set; } = new();

    public string DisplayName { get; set; } = string.Empty;

    public string EnhancedMlsDisplayName { get; set; } = string.Empty;
}