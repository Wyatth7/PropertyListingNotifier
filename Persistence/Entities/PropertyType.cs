using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class PropertyType
{
    [Key]
    public int PropertyTypeId { get; set; }

    [MaxLength(500)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Property> Property { get; set; } = new HashSet<Property>();
}