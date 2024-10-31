using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.AddressId);

        builder.HasOne(p => p.Property)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(p => p.PropertyId)
            .IsRequired();

        builder.Property(p => p.ListingAddressFull)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(p => p.ListingAddress1)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(p => p.ListingAddress2)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.City)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.State)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Country)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.PostalCode)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Timezone)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(100)
            .IsRequired();

    }
}