using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(new Product()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Tükenmez Kalem",
                Description = "Tükenmez Kalem Description",
                Price = 10,
                Stock = 10000,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new Product()
            {
                Id = 2,
                CategoryId = 2,
                Name = "Çizgisiz Defter",
                Description = "Çizgisiz Defter Description",
                Price = 200,
                Stock = 200,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new Product()
            {
                Id = 3,
                CategoryId = 3,
                Name = "Spor Çantası",
                Description = "Spor Çantası Description",
                Price = 31,
                Stock = 3300,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new Product()
            {
                Id = 4,
                CategoryId = 4,
                Name = "Kılıf",
                Description = "Kılıf Description",
                Price = 250,
                Stock = 6400,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new Product()
            {
                Id = 5,
                CategoryId = 5,
                Name = "Play Doh Oyun Hamuru",
                Description = "Play Doh Oyun Hamuru Description",
                Price = 420,
                Stock = 1300,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            }
        );
    }
}