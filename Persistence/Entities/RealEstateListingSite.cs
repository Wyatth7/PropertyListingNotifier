using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class RealEstateListingSite
{
    [Key]
    public int RealEstateListingSiteId { get; set; }

    [MaxLength(500)]
    public string Name { get; set; } = string.Empty;

    public Listing? Listing { get; set; }
}