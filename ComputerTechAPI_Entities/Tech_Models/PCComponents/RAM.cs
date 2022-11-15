using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.PCComponents;

public class RAM
{

    [Column("RAMId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "RAM name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Ram Capacity is a required field.")]
    public string? RamCapacity { get; set; }

    [Required(ErrorMessage = "Ram Speed is a required field.")]
    public string? RAMSpeed { get; set; }

    [Required(ErrorMessage = "RAM Type is a required field.")]
    public string? RAMType { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
