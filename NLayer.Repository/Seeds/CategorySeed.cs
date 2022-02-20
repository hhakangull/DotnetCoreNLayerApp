using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds;

public class CategorySeed: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Kalemler",
                Description = "Kalemler Description"
            },
            new Category
            {
                Id = 2,
                Name = "Defterler",
                Description = "Defterler Description"
            },
            new Category
            {
                Id = 3,
                Name = "Çantalar",
                Description = "Çantalar Description"
            },
            new Category
            {
                Id = 4,
                Name = "Kılıflar",
                Description = "Kılıflar Description"
            },
            new Category
            {
                Id = 5,
                Name = "Oyun Hamurları",
                Description = "Oyun Hamurları Description"
            }
        );
    }
}