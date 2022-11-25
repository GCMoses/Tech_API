using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public abstract record CaseModifiedDTO
{
    [Required(ErrorMessage = "Case name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Form Factor is a required field.")]
    public string? FormFactor { get; set; }

    [Required(ErrorMessage = "Drive Bay is a required field.")]
    public int DriveBays { get; set; }

    [Required(ErrorMessage = "Expansion Slots is a required field.")]
    public int ExpansionSlots { get; set; }

    [Required(ErrorMessage = "Fan Support is a required field.")]
    public string? FanSupport { get; set; }

    [Required(ErrorMessage = "GPU Lenght Limit is a required field.")]
    public string? GPULenghtLimit { get; set; }

    [Required(ErrorMessage = "Net Weight is a required field.")]
    public string? NetWeight { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}