using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.Accessories;

public class GamingHeadphonesAndHeadset
{
    [Column("GamingHeadphonesAndHeadsetId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Interface is a required field.")]
    public string? Interface { get; set; }

    [Required(ErrorMessage = "Connector is a required field.")]
    public string? Connector { get; set; }

    [Required(ErrorMessage = "Headphone Compatability is a required field.")]
    public string? Compatability { get; set; }

    [Required(ErrorMessage = "Foldability is a required field.")]
    public string? Foldability { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
