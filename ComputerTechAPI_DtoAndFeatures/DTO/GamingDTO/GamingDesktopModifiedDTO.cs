using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;


public abstract record GamingDesktopModifiedDTO
{
    [Required(ErrorMessage = "Desktop name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Image URL is a required field.")]
    public string? ImgURL { get; set; }

    [Required(ErrorMessage = "Gaming Case is a required field.")]
    public string? GamingCase { get; set; }

    [Required(ErrorMessage = "Cooling System name is a required field.")]
    public string? CoolingSystem { get; set; }

    [Required(ErrorMessage = "Processor is a required field.")]
    public string? Processor { get; set; }

    [DisplayName("HDD/SSD")]
    [Required(ErrorMessage = "HardDisk is a required field.")]
    public string? HardDisk { get; set; }

    [DisplayName("RAM")]
    [Required(ErrorMessage = "RAM is a required field.")]
    public string? Ram { get; set; }

    [DisplayName("Operating System")]
    [Required(ErrorMessage = "Operating System is a required field.")]
    public string? OS { get; set; }

    [DisplayName("GPU")]
    [Required(ErrorMessage = "Graphics is a required field.")]
    public string? Graphics { get; set; }

    [Required(ErrorMessage = "Gaming Desktop PSU is a required field.")]
    public string? PSU { get; set; }


    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Required(ErrorMessage = "Short Description is a required field.")]
    public string? GamingPCDescription { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}