using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PCComponents;

public class HDD
{

    [Column("HDDId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "HDD name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Storage Capacity name is a required field.")]
    public string? StorageCapacity { get; set; }

    [Required(ErrorMessage = "Interface  is a required field.")]
    public string? Interface { get; set; }


    [Required(ErrorMessage = "Cache Size is a required field.")]
    public string? CacheSize { get; set; }

    [Required(ErrorMessage = "Form Factor is a required field.")]
    public string? FormFactor { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
