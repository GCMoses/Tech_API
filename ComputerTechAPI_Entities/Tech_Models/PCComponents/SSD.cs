using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PCComponents;

public class SSD
{

    [Column("SSDId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "SSD name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Storage Capacity is a required field.")]
    public string? StorageCapacity { get; set; }

    [Required(ErrorMessage = "Read/Write Speed is a required field.")]
    public string? ReadWriteSpeed { get; set; }

    [Required(ErrorMessage = "Form Factor is a required field.")]
    public string? FormFactor { get; set; }

    [Required(ErrorMessage = "Interface is a required field.")]
    public string? Interface { get; set; }

    [Required(ErrorMessage = "Cache Memory is a required field.")]
    public string? CacheMemory { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
