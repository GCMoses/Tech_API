using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PCComponents;

public class PSU
{
    [Column("PSUId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "PSU name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Rated Output Power is a required field.")]
    public string? RatedOutputPower { get; set; }

    [Required(ErrorMessage = "Plus Certified is a required field.")]
    public string? PlusCertified { get; set; }

    [Required(ErrorMessage = "Connectors is a required field.")]
    public string? Connectors { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
