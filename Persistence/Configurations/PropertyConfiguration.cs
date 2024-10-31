using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(x => x.PropertyId);

        builder.HasOne(p => p.Listing)
            .WithMany(p => p.Properties)
            .HasForeignKey(p => p.ListingId)
            .IsRequired();
        
        builder.HasOne(p => p.ListingAgent)
            .WithMany()
            .HasForeignKey(p => p.ListingAgentId);
            
        builder.HasOne(p => p.ListingOffice)
            .WithMany()
            .HasForeignKey(p => p.ListingOfficeId);

        builder.HasOne(p => p.PropertyType)
            .WithMany(p => p.Property)
            .HasForeignKey(p => p.PropertyTypeId)
            .IsRequired();

        builder.HasOne(p => p.Resource)
            .WithOne(p => p.Property)
            .HasForeignKey<Property>(p => p.ResourceId)
            .IsRequired();
    }
}