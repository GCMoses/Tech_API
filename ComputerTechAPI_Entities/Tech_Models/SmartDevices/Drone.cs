using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.SmartDevices;

public class Drone
{
    [Column("DroneId")]
    public Guid Id { get; set; }
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

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
