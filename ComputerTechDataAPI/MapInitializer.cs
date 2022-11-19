using AutoMapper;
using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechDataAPI;

public class MapInitializer : Profile
{
    public MapInitializer()
    {
        CreateMap<Product, ProductDTO>();
        //Accessories
        CreateMap<GamingHeadphonesAndHeadset, GamingHeadphonesAndHeadsetDTO>();
        CreateMap<GamingKeyboard, GamingKeyboardDTO>();
        CreateMap<GamingMouse, GamingMouseDTO>();
        //Gaming
        CreateMap<GamingConsole, GamingConsoleDTO>();
        CreateMap<GamingDesktop, GamingDesktopDTO>();
        CreateMap<GamingLaptop, GamingLaptopDTO>();
        //Networking
        CreateMap<Router, RouterDTO>();
        //PC
        CreateMap<Desktop, DesktopDTO>();
        CreateMap<Laptop, LaptopDTO>();
        //PC Components
        CreateMap<Case, CaseDTO>();
        CreateMap<CPUCooler, CPUCoolerDTO>();
        CreateMap<CPU, CPUDTO>();
        CreateMap<GPU, GPUDTO>();
        CreateMap<HDD, HDDDTO>();
        CreateMap<Motherboard, MotherboardDTO>();
        CreateMap<PSU, PSUDTO>();
        CreateMap<RAM, RAMDTO>();
        CreateMap<SSD, SSDDTO>();
        //Smart Devices
        CreateMap<Drone, DroneDTO>();
        CreateMap<SmartPhone, SmartPhoneDTO>();

    }
}

