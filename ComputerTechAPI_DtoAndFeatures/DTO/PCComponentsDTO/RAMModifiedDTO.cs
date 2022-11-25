using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public abstract record RAMModifiedDTO
{
    [Required(ErrorMessage = "RAM name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "RAM Capacity is a required field.")]
    public string? RamCapacity { get; set; }

    [Required(ErrorMessage = "RAM Speed is a required field.")]
    public string? RAMSpeed { get; set; }

    [Required(ErrorMessage = "RAM Type is a required field.")]
    public string? RAMType { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}