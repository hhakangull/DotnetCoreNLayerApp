using System.ComponentModel.DataAnnotations;

namespace NLayer.Core;

public abstract class BaseEntity
{
    // [Key]
    // public int Category_Id { get; set; }
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}