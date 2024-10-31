using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Entities;

[Index(nameof(ListingProviderId), Name = "IX_Listing_ListingProviderId")]
public class Listing
{
    [Key]
    public int ListingId { get; set; }

    [ForeignKey(nameof(RealEstateListingSiteId))]
    public int RealEstateListingSiteId { get; set; }

    [ForeignKey(nameof(ResourceId))]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(250)]
    public string ListingProviderId { get; set; } = string.Empty;
    
    public RealEstateListingSite? RealEstateListingSite { get; set; }

    public Resource? Resource { get; set; }

    public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
}