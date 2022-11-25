using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;


public abstract record RouterModifiedDTO
{
    [Required(ErrorMessage = "Router name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Wi-Fi Standard is a required field.")]
    public string? RAM { get; set; }

    [Required(ErrorMessage = "Transfer Rate is a required field.")]
    public string? TransferRate { get; set; }

    [Required(ErrorMessage = "Wi-Fi Ports is a required field.")]
    public string? WiFiPorts { get; set; }

    [Required(ErrorMessage = "MU_MIMO is a required field.")]
    public string? MU_MIMO { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}