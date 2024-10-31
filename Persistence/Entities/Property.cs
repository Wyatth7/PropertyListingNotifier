using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class Property
{
    [Key]
    public int PropertyId { get; set; }

    public int ListingId { get; set; }

    public int? ListingAgentId { get; set; }

    public int? ListingOfficeId { get; set; }

    public int PropertyTypeId { get; set; }

    public int ResourceId { get; set; }


    public Listing? Listing { get; set; }

    public Address? Address { get; set; }

    public ListingEntity? ListingAgent { get; set; }

    public ListingEntity? ListingOffice { get; set; }

    public PropertyType? PropertyType { get; set; }

    public Resource? Resource { get; set; }

    public PropertyDetails? PropertyDetails { get; set; }
}
