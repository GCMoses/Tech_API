using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PCComponents;

public class GPU
{
    [Column("GPUId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "GPU name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Bus is a required field.")]
    public string? Bus { get; set; }

    [Required(ErrorMessage = "GPU clock is a required field.")]
    public string? GPUClock { get; set; }

    [Required(ErrorMessage = "VRAM is a required field.")]
    public string? VRAM { get; set; }

    [Required(ErrorMessage = "Interface is a required field.")]
    public string? Interface { get; set; }

    [Required(ErrorMessage = "CoolingType is a required field.")]
    public string? CoolingType { get; set; }

    [Required(ErrorMessage = "DX Version is a required field.")]
    public string? DXVersion { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
