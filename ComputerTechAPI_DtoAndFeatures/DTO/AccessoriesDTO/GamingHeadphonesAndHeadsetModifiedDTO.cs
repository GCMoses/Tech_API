using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;


public abstract record GamingHeadphonesAndHeadsetModifiedDTO
{
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
}

