using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;


public abstract record GamingMouseModifiedDTO
{
    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "PollRate is a required field.")]
    public string? PollRate { get; set; }

    [Required(ErrorMessage = "Connector is a required field.")]
    public string? Connector { get; set; }

    [Required(ErrorMessage = "Buttons is a required field.")]
    public string? Buttons { get; set; }

    [Required(ErrorMessage = "Weight is a required field.")]
    public string? Weight { get; set; }

    [Required(ErrorMessage = "Lighting is a required field.")]
    public string? Lighting { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; } 
}

