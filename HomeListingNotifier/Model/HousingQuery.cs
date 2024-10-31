using HomeListingNotifier.Model.Remax;

namespace HomeListingNotifier.Model;

public class HousingQuery
{
    public string Name { get; set; } = string.Empty;

    public string OutboundUrl { get; set; } = string.Empty;

    public RemaxFilter RequestFilter { get; set; } = new();

    public object Body { get; set; } = null!;
}