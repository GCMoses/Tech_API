using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;


public record DroneModifiedDTO
{
    [Required(ErrorMessage = "Drone name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Flight Time is a required field.")]
    public string? FlightTime { get; set; }

    [Required(ErrorMessage = "Top Speed is a required field.")]
    public string? MaxSpeed { get; set; }

    [Required(ErrorMessage = "Remote Controller is a required field.")]
    public string? RemoteController { get; set; }

    [Required(ErrorMessage = "Camera is a required field.")]
    public string? Camera { get; set; }

    [Required(ErrorMessage = "Battery Life is a required field.")]
    public string? BatteryLife { get; set; }

    [Required(ErrorMessage = "Price in Rand is a required field.")]
    public string? Price { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }
}