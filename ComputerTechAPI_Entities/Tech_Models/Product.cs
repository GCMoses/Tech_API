using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Entities.Tech_Models;

public class Product
{
    [Column("ProductId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Category is a required field.")]
    public string? Category { get; set; }


    public ICollection<Laptop>? Laptops { get; set; }
    public ICollection<GamingLaptop>? GamingLaptops { get; set; }
    public ICollection<Desktop>? Desktops { get; set; }
    public ICollection<GamingDesktop>? GamingDesktops { get; set; }
    public ICollection<CPUCooler>? CPUCoolers{ get; set; }
    public ICollection<HDD>? HDDs { get; set; }
    public ICollection<RAM>? RAMs { get; set; }
    public ICollection<GPU>? GPUs { get; set; }
    public ICollection<CPU>? CPUs { get; set; }
    public ICollection<PSU>? PSUs { get; set; }
    public ICollection<Motherboard>? Motherboards { get; set; }
    public ICollection<Case>? Cases { get; set; }
    public ICollection<Router>? Routers { get; set; }
    public ICollection<GamingConsole>? GamingConsoles { get; set; }
    public ICollection<Drone>? Drones { get; set; }
    public ICollection<GamingHeadphonesAndHeadset>? GamingHeadphonesAndHeadsets { get; set; }
    public ICollection<GamingKeyboard>? GamingKeyboards { get; set; }
    public ICollection<GamingMouse>? GamingMouses { get; set; }
    public ICollection<SmartPhone>? SmartPhones { get; set; }
    public ICollection<SSD>? SSDs { get; set; }
}
