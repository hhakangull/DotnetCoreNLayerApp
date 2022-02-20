using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configuration;

namespace NLayer.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // yada alttaki gibi entegrasyon yapılabilir.
        // modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());

        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1
            }, new ProductFeature()
            {
                Id = 2,
                Color = "Siyah",
                Height = 200,
                Width = 300,
                ProductId = 2
            },
            new ProductFeature()
            {
                Id = 3,
                Color = "Yeşil",
                Height = 300,
                Width = 400,
                ProductId = 3
            });
        base.OnModelCreating(modelBuilder);
    }
}