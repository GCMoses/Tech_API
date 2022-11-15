using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_Entities.Tech_Models.SmartDevices;

public class SmartPhone
{
    [Column("SmartPhoneId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Smart Phone name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Image URL is a required field.")]
    public string? ImgURL { get; set; }

    [Required(ErrorMessage = "Battery Life is a required field.")]
    public string? BatteryLife { get; set; }

    [Required(ErrorMessage = "PlatForm is a required field.")]
    public string? PlatForm { get; set; }

    [Required(ErrorMessage = "Storage is a required field.")]
    public string? Storage { get; set; }

    [Required(ErrorMessage = "Processor is a required field.")]
    public string? Processor { get; set; }

    [Required(ErrorMessage = "RAM is a required field.")]
    public string? RAM { get; set; }

    [Required(ErrorMessage = "Screen Size is a required field.")]
    public string? ScreenSize { get; set; }

    [Required(ErrorMessage = "Camera is a required field.")]
    public string? Camera { get; set; }

    [Required(ErrorMessage = "Sensors is a required field.")]
    public string? Sensors { get; set; }

    [Required(ErrorMessage = "Charger Type is a required field.")]
    public string? ChargerType { get; set; }

    [Required(ErrorMessage = "Software Version is a required field.")]
    public string? SoftwareVersion { get; set; }

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
