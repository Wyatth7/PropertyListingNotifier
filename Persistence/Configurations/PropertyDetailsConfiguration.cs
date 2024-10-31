using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class PropertyDetailsConfiguration : IEntityTypeConfiguration<PropertyDetails>
{
    public void Configure(EntityTypeBuilder<PropertyDetails> builder)
    {
        builder.HasKey(p => p.PropertyDetailsId);

        builder.Property(p => p.BaseImageUrl)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.HasOne(p => p.Property)
            .WithOne(p => p.PropertyDetails)
            .HasForeignKey<PropertyDetails>(p => p.PropertyId)
            .IsRequired();
    }
}