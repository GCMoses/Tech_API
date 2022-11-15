using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PC;

public class Desktop
{
    [Column("DesktopId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Desktop name is a required field.")]
    [MaxLength(100, ErrorMessage = "Maximum length for the Desktop PC Name is 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Model name is a required field.")]
    public string? Model { get; set; }


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

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }


    [Required(ErrorMessage = "Desktop Description is a required field.")]
    public string? DesktopPCDescription { get; set; }

    [Required(ErrorMessage = "Desktop PC Rating is a required field.")]
    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
