using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;


public abstract record GamingKeyboardModifiedDTO
{
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
}