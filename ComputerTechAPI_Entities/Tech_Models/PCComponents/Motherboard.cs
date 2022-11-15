using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PCComponents;

public class Motherboard
{

    [Column("MotherboardId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Motherboard name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Motherboard Name is 100 characters.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "MoboCPU is a required field.")]
    public string? MoboCPU { get; set; }

    [Required(ErrorMessage = "Chipset name is a required field.")]
    public string? Chipset { get; set; }

    [Required(ErrorMessage = "Memory is a required field.")]
    public string? MoboMaxMemory { get; set; }

    [Required(ErrorMessage = "Graphics is a required field.")]
    public string? PCIExpress { get; set; }

    [Required(ErrorMessage = "Mobo USB Ports is a required field.")]
    public string? MoboUSBPorts { get; set; }

    [Required(ErrorMessage = "Mobo Connectors is a required field.")]
    public string? MoboConnectors { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
