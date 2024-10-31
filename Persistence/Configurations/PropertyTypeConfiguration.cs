using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

/// <summary>
/// Configuration for seeding ONLY
/// </summary>
public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
{
    public void Configure(EntityTypeBuilder<PropertyType> builder)
    {

        builder.HasData(
            new PropertyType { PropertyTypeId = (int)Entities.Types.PropertyType.SingleFamily, Name = "Single Family" },
            new PropertyType { PropertyTypeId = (int)Entities.Types.PropertyType.Land, Name = "Land" }
        );

    }
}