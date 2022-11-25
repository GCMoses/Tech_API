using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public abstract record MotherboardModifiedDTO
{
    [Required(ErrorMessage = "Motherboard name is a required field.")]
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
}