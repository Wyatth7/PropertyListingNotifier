using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class PropertyDetails
{
    public int PropertyDetailsId { get; set; }

    public int PropertyId { get; set; }
    
    public float Bedrooms { get; set; }

    public float Bathrooms { get; set; }

    public float LotSizeSqFeet { get; set; }

    public float LotSizeAcres { get; set; }

    public float LivingArea { get; set; }

    public decimal Price { get; set; }

    public decimal PriceChange { get; set; }

    public int YearBuilt { get; set; }

    public string BaseImageUrl { get; set; } = string.Empty;

    public Property? Property { get; set; }
}