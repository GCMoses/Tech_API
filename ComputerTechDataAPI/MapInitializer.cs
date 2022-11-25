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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ComputerTechDataAPI;

public class MapInitializer : Profile
{
    public MapInitializer()
    {
        //Mapping Model Entities to DTOs
        //DTO TO ENTITIES

        CreateMap<Product, ProductDTO>();
        //Accessories mapping
        CreateMap<GamingHeadphonesAndHeadset, GamingHeadphonesAndHeadsetDTO>();
        CreateMap<GamingKeyboard, GamingKeyboardDTO>();
        CreateMap<GamingMouse, GamingMouseDTO>();
        //Gaming mapping
        CreateMap<GamingConsole, GamingConsoleDTO>();
        CreateMap<GamingDesktop, GamingDesktopDTO>();
        CreateMap<GamingLaptop, GamingLaptopDTO>();
        //Networking mapping
        CreateMap<Router, RouterDTO>();
        //PC mapping
        CreateMap<Desktop, DesktopDTO>();
        CreateMap<Laptop, LaptopDTO>();
        //PC Components mapping
        CreateMap<Case, CaseDTO>();
        CreateMap<CPUCooler, CPUCoolerDTO>();
        CreateMap<CPU, CPUDTO>();
        CreateMap<GPU, GPUDTO>();
        CreateMap<HDD, HDDDTO>();
        CreateMap<Motherboard, MotherboardDTO>();
        CreateMap<PSU, PSUDTO>();
        CreateMap<RAM, RAMDTO>();
        CreateMap<SSD, SSDDTO>();
        //Smart Devices mapping
        CreateMap<Drone, DroneDTO>();
        CreateMap<SmartPhone, SmartPhoneDTO>();


        //CreateDTO Entities
        //CREATE ENTITIES
        CreateMap<ProductCreateDTO, Product>();
        //Accessories CreateDTO mapping 
        CreateMap<GamingHeadphonesAndHeadsetCreateDTO, GamingHeadphonesAndHeadset>();
        CreateMap<GamingKeyboardCreateDTO, GamingKeyboard>();
        CreateMap<GamingMouseCreateDTO, GamingMouse>();
        //Gaming CreateDTO mapping 
        CreateMap<GamingConsoleCreateDTO, GamingConsole>();
        CreateMap<GamingDesktopCreateDTO, GamingDesktop>();
        CreateMap<GamingLaptopCreateDTO, GamingLaptop>();
        //Networking CreateDTO mapping 
        CreateMap<RouterCreateDTO, Router>();
        //PC CreateDTO mapping 
        CreateMap<DesktopCreateDTO, Desktop>();
        CreateMap<LaptopCreateDTO, Laptop>();
        //PC Components CreateDTO mapping
        CreateMap<CaseCreateDTO, Case>();
        CreateMap<CPUCoolerCreateDTO, CPUCooler>();
        CreateMap<CPUCreateDTO, CPU>();
        CreateMap<GPUCreateDTO, GPU>();
        CreateMap<HDDCreateDTO, HDD>();
        CreateMap<MotherboardCreateDTO, Motherboard>();
        CreateMap<PSUCreateDTO, PSU>();
        CreateMap<RAMCreateDTO, RAM>();
        CreateMap<SSDCreateDTO, SSD>();
        //Smart Devices CreateDTO mapping
        CreateMap<DroneCreateDTO, Drone>();
        CreateMap<SmartPhoneCreateDTO, SmartPhone>();
    
        //Update Map
        //UPDATE ENTITIES
        CreateMap<GamingHeadphonesAndHeadsetUpdateDTO, GamingHeadphonesAndHeadset>();
        CreateMap<GamingKeyboardUpdateDTO, GamingKeyboard>();
        CreateMap<GamingMouseUpdateDTO, GamingMouse>();
        //Gaming Update mapping 
        CreateMap<GamingConsoleUpdateDTO, GamingConsole>();
        CreateMap<GamingDesktopUpdateDTO, GamingDesktop>();
        CreateMap<GamingLaptopUpdateDTO, GamingLaptop>();
        //Networking UpdateDTO mapping 
        CreateMap<RouterUpdateDTO, Router>();
        //PC UpdateDTO mapping 
        CreateMap<DesktopUpdateDTO, Desktop>();
        CreateMap<LaptopUpdateDTO, Laptop>();
        //PC Components UpdateDTO mapping
        CreateMap<CaseUpdateDTO, Case>();
        CreateMap<CPUCoolerUpdateDTO, CPUCooler>();
        CreateMap<CPUUpdateDTO, CPU>();
        CreateMap<GPUUpdateDTO, GPU>();
        CreateMap<HDDUpdateDTO, HDD>();
        CreateMap<MotherboardUpdateDTO, Motherboard>();
        CreateMap<PSUUpdateDTO, PSU>();
        CreateMap<RAMUpdateDTO, RAM>();
        CreateMap<SSDUpdateDTO, SSD>();
        //Smart Devices UpdateDTO mapping
        CreateMap<DroneUpdateDTO, Drone>();
        CreateMap<SmartPhoneUpdateDTO, SmartPhone>();



       

        //ReverseMapping
        //REVERSEMAP UPDATE ENTITIES
        CreateMap<ProductUpdateDTO, Product>().ReverseMap();

        //Accessories UpdateDTO mapping 
        CreateMap<GamingHeadphonesAndHeadsetUpdateDTO, GamingHeadphonesAndHeadset>().ReverseMap();

        CreateMap<GamingKeyboardUpdateDTO, GamingKeyboard>().ReverseMap();

        CreateMap<GamingMouseUpdateDTO, GamingMouse>().ReverseMap();
        ;
        //Gaming Update mapping 
        CreateMap<GamingConsoleUpdateDTO, GamingConsole>().ReverseMap();
        ;
        CreateMap<GamingDesktopUpdateDTO, GamingDesktop>().ReverseMap();
        ;
        CreateMap<GamingLaptopUpdateDTO, GamingLaptop>().ReverseMap();
        //Networking UpdateDTO mapping 
        CreateMap<RouterUpdateDTO, Router>().ReverseMap();
        //PC UpdateDTO mapping 
        CreateMap<DesktopUpdateDTO, Desktop>().ReverseMap();
        CreateMap<LaptopUpdateDTO, Laptop>().ReverseMap();
        //PC Components UpdateDTO mapping
        CreateMap<CaseUpdateDTO, Case>().ReverseMap();
        CreateMap<CPUCoolerUpdateDTO, CPUCooler>().ReverseMap();
        CreateMap<CPUUpdateDTO, CPU>().ReverseMap();
        CreateMap<GPUUpdateDTO, GPU>().ReverseMap();
        CreateMap<HDDUpdateDTO, HDD>().ReverseMap();
        CreateMap<MotherboardUpdateDTO, Motherboard>().ReverseMap();
        CreateMap<PSUUpdateDTO, PSU>().ReverseMap();
        CreateMap<RAMUpdateDTO, RAM>().ReverseMap();
        CreateMap<SSDUpdateDTO, SSD>().ReverseMap();
        //Smart Devices UpdateDTO mapping
        CreateMap<DroneUpdateDTO, Drone>().ReverseMap();
        CreateMap<SmartPhoneUpdateDTO, SmartPhone>().ReverseMap();


        //ReverseMapping
        
    }
}

