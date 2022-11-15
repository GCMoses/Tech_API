using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.Accessories;
public class GamingKeyboard 
{
    [Column("GamingKeyboardId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Matrix is a required field.")]
    public string? Matrix { get; set; }

    [Required(ErrorMessage = "Connector is a required field.")]
    public string? Connector { get; set; }

    [Required(ErrorMessage = "Keyboard Layout is a required field.")]
    public string? KeyboardLayout { get; set; }

    [Required(ErrorMessage = "Lighting is a required field.")]
    public string? Lighting { get; set; }

    [Required(ErrorMessage = "Key switches is a required field.")]
    public string? KeySwitches { get; set; }

    [Required(ErrorMessage = "Adjustable Height is a required field.")]
    public string? AdjustableHeight { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
