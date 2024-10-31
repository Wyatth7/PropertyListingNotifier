using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;
using Persistence.Entities.Types;

namespace Persistence.Configurations;

/// <summary>
/// Configuration for seeding data ONLY
/// </summary>
public class RealEstateListingSiteConfiguration : IEntityTypeConfiguration<RealEstateListingSite>
{
    public void Configure(EntityTypeBuilder<RealEstateListingSite> builder)
    {
        builder.HasData(
            new RealEstateListingSite { RealEstateListingSiteId = (int)RealEstateSite.Remax, Name = "Remax" },
            new RealEstateListingSite { RealEstateListingSiteId = (int)RealEstateSite.Zillow, Name = "Zillow" }
        );
    }
}