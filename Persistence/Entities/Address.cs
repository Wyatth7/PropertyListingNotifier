namespace Persistence.Entities;

public class Address
{
    public int AddressId { get; set; }

    public int PropertyId { get; set; }

    public string ListingAddressFull { get; set; } = string.Empty;

    public string ListingAddress1 { get; set; } = string.Empty;

    public string ListingAddress2 { get; set; } = string.Empty;
    
    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string Timezone { get; set; } = string.Empty;
    
    public Property? Property { get; set; }
}
