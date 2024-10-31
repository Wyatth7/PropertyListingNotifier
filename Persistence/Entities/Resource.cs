using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }
    
    public string Data { get; set; } = string.Empty;

    public Listing? Listing { get; set; }

    public Property? Property { get; set; }
}