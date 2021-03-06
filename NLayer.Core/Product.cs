namespace NLayer.Core;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ProductFeature ProductFeature { get; set; }
}