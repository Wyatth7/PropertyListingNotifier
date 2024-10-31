using Mapster;

namespace HomeListingNotifier.Model.Remax;

/// <summary>
/// The following data is what may be returned from Remax.
/// The values returned with each property are not strictly typed,
/// so objects must be used to account for this.
///
/// To add to this, every property also seems to be nullable, so checking here is required.
/// </summary>
///
/// TODO: NEED TO MAKE THIS A DTO, AND MAP TO A GENERIC MODEL WHEN ADDING ZILLOW INTO THE APP
public class ListingData
{
    public object? ComputedBathroomsTotalInteger { get; set; }

    public object? BathroomsFull { get; set; }

    public object? LotSizeAcres { get; set; }

    public object? BedroomsTotal { get; set; }

    public bool? InternetAddressDisplayYn { get; set; }

    public object? RetrievedPhotosCount { get; set; }

    public string? UniqueListingId { get; set; } = string.Empty;

    public DateTimeOffset? ModificationTimestamp { get; set; }

    public RemaxImages[]? Images { get; set; }

    public string? DisplayedListingId { get; set; } = string.Empty;

    public object? BathroomsTotalInteger { get; set; }

    public RemaxImageUrls? ImageUrls { get; set; }

    public string? City { get; set; } = string.Empty;

    public string? StandardStatus { get; set; } = string.Empty;

    public object? LotSizeSquareFeet { get; set; }

    public string? CalculatedCity { get; set; } = string.Empty;

    public string? BaseListingImage { get; set; } = string.Empty;

    public DateTimeOffset? ComputedOnMarketDate { get; set; }

    public RemaxCompliance? Compliance { get; set; }

    public string? ListingAgentFullName { get; set; } = string.Empty;

    public string? ListAgentPhone { get; set; } = string.Empty;

    public string? ListingAgentPreferredPhone { get; set; } = string.Empty;

    public string? ListOfficeEmail { get; set; } = string.Empty;

    public string? ListOfficePhone { get; set; } = string.Empty;

    public string? ListOfficeName { get; set; } = string.Empty;

    public string? ListPrice { get; set; } = string.Empty;

    public DateTimeOffset? ListingContractDate { get; set; }

    [AdaptIgnore]
    public string? ListingId { get; set; } = string.Empty;

    public RemaxImages[]? ListingImages { get; set; } = [];

    public object? LivingArea { get; set; }

    public Address? Location { get; set; }

    public object? LotSize { get; set; }

    public object? LotSizeSqFeet { get; set; }

    public string? Ouid { get; set; } = string.Empty;

    public object? PriceChangeAmount { get; set; }

    public string? PropertySubType { get; set; } = string.Empty;

    public string? PropertyType { get; set; } = string.Empty;

    public string? RawPropertyType { get; set; } = string.Empty;

    public string? Status { get; set; } = string.Empty;

    public string? Upi { get; set; } = string.Empty;

    public object? YearBuilt { get; set; }
}