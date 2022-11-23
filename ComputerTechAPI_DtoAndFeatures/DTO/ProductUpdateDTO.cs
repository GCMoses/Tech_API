using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;

namespace ComputerTechAPI_DtoAndFeatures.DTO;



public record ProductUpdateDTO
{

    public string? Category { get; init; }
    //Accessories
    //IEnumerable<GamingHeadphonesAndHeadsetCreateDTO>? GamingHeadphonesAndHeadsets;
    //IEnumerable<GamingKeyboardCreateDTO>? GamingKeyboards;
    //IEnumerable<GamingMouseCreateDTO>? GamingMouses;
    //Gaming
    //IEnumerable<GamingConsoleCreateDTO>? GamingConsoles;
    //IEnumerable<GamingDesktopCreateDTO>? GamingDesktops;
    //IEnumerable<GamingLaptopCreateDTO>? GamingLaptops;
    //NEtworking
    //IEnumerable<RouterCreateDTO>? Routers;
    //PC
    //IEnumerable<DesktopCreateDTO>? Desktops;
    //IEnumerable<LaptopCreateDTO>? Laptops;
    //PC Components
    //IEnumerable<CaseCreateDTO>? pcCases;
    //IEnumerable<CPUCoolerCreateDTO>? CPUCoolers;
    //IEnumerable<CPUCreateDTO>? CPUs;
    //IEnumerable<GPUCreateDTO>? GPUs;
    //IEnumerable<HDDCreateDTO>? HDDs;
    //IEnumerable<MotherboardCreateDTO>? Motherboards;
    //IEnumerable<PSUCreateDTO>? PSUs;
    //IEnumerable<RAMCreateDTO>? RAMs;
    //IEnumerable<SSDCreateDTO>? SSDs;
    //Smart Devices
    //IEnumerable<DroneCreateDTO>? Drones;
    //IEnumerable<SmartPhoneCreateDTO>? SmartPhones;
}
