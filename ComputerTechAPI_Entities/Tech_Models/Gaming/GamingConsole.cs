using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.Gaming;

public class GamingConsole
{
    [Column("GamingConsoleId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Gaming Console name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Image URL is a required field.")]
    public string? ImgURL { get; set; }

    [Required(ErrorMessage = "Model name is a required field.")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Disk Drive is a required field.")]
    public string? DiskDrive { get; set; }

    [DisplayName("Resolution and Screen Frame Rate")]
    [Required(ErrorMessage = "Resolution and Screen Frame Rat is a required field.")]
    public string? ResolutionAndFrameRate { get; set; }

    [Required(ErrorMessage = "HardDisk is a required field.")]
    public string? HardDisk { get; set; }

    [Required(ErrorMessage = "Processor is a required field.")]
    public string? Processor { get; set; }

    [Required(ErrorMessage = "Graphics is a required field.")]
    public string? Graphics { get; set; }

    [Required(ErrorMessage = "RAM is a required field.")]
    public string? RAM { get; set; }

    [Required(ErrorMessage = "Controller is a required field.")]
    public string? Controller { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Required(ErrorMessage = "Short Description is a required field.")]
    public string? ShortDescription { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
