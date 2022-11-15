using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerTechAPI_Entities.Tech_Models.Networking;

public class Router
{

    [Column("RouterId")]
    public Guid Id { get; set; }
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

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
