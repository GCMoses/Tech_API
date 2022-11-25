using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;

namespace ComputerTechAPI_DtoAndFeatures.DTO;



public abstract record ProductModifiedDTO
{

    public string? Category { get; init; }
    //Accessories
    public IEnumerable<GamingHeadphonesAndHeadsetCreateDTO>? GamingHeadphonesAndHeadsets { get; init; }
    public  IEnumerable<GamingKeyboardCreateDTO>? GamingKeyboards { get; init; }
    public  IEnumerable<GamingMouseCreateDTO>? GamingMouses { get; init; }
    //Gaming
    public  IEnumerable<GamingConsoleCreateDTO>? GamingConsoles { get; init; }
    public IEnumerable<GamingDesktopCreateDTO>? GamingDesktops { get; init; }
    public IEnumerable<GamingLaptopCreateDTO>? GamingLaptops { get; init; }
    //Networking
    public IEnumerable<RouterCreateDTO>? Routers { get; init; }
    //PC
    public IEnumerable<DesktopCreateDTO>? Desktops { get; init; }
    public IEnumerable<LaptopCreateDTO>? Laptops { get; init; }
    //PC Components
    public IEnumerable<CaseCreateDTO>? pcCases { get; init; }
    public IEnumerable<CPUCoolerCreateDTO>? CPUCoolers { get; init; }
    public IEnumerable<CPUCreateDTO>? CPUs { get; init; }
    public IEnumerable<GPUCreateDTO>? GPUs { get; init; }
    public IEnumerable<HDDCreateDTO>? HDDs { get; init; }
    public IEnumerable<MotherboardCreateDTO>? Motherboards { get; init; }
    public IEnumerable<PSUCreateDTO>? PSUs { get; init; }
    public IEnumerable<RAMCreateDTO>? RAMs { get; init; }
    IEnumerable<SSDCreateDTO>? SSDs { get; init; }
//Smart Devices
    public IEnumerable<DroneCreateDTO>? Drones { get; init; }
    public IEnumerable<SmartPhoneCreateDTO>? SmartPhones { get; init; }
}
