using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence;

public class ListingDbContext : DbContext
{
    public string DbPath { get; }
    
    public ListingDbContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, "listing-data.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Listing> Listings { get; set; }

    public DbSet<Property> Property { get; set; }

    public DbSet<PropertyDetails> PropertyDetails { get; set; }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<RealEstateListingSite> RealEstateListingSites { get; set; }

    public DbSet<PropertyType> PropertyTypes { get; set; }

    public DbSet<ListingEntity> ListingEntities { get; set; }

    public DbSet<Address> Addresses { get; set; }
}