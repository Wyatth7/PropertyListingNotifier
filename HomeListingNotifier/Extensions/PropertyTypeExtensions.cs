using Persistence.Entities.Types;

namespace HomeListingNotifier.Extensions;

public static class PropertyTypeExtensions
{
    private const string SingleFamilyHome = "Single Family Home";
    private const string SingleFamily = "Single Family";
    private const string Land = "Land";
    
    public static PropertyType TryGetPropertyType(this string value)
    {
        return value switch
        {
            SingleFamilyHome => PropertyType.SingleFamily,
            SingleFamily => PropertyType.SingleFamily,
            Land => PropertyType.Land,
            _ => PropertyType.Ignore
        };
    }
}