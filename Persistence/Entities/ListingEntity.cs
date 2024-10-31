using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class ListingEntity
{
    [Key]
    public int ListingEntityId { get; set; }

    [MaxLength(500)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Phone { get; set; } = string.Empty;

    public Property? Property { get; set; }
}