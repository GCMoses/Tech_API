using ComputerTechAPI_Contracts.ITech;
using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_Contracts.ITech.ITech_Networking;
using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;


namespace ComputerTechAPI_Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductRepository { get; }
    //Accessories
    IGamingHeadphonesAndHeadsetRepository GamingHeadphonesAndHeadsetRepository { get; }
    IGamingKeyboardRepository GamingKeyboardRepository { get; }
    IGamingMouseRepository GamingMouseRepository { get; }
    //Gaming
    IGamingConsoleRepository GamingConsoleRepository { get; }
    IGamingDesktopRepository GamingDesktopRepository { get; }
    IGamingLaptopRepository GamingLaptopRepository { get; }
    //Networking
    IRouterRepository RouterRepository { get; }
    //PC
    IDesktopRepository DesktopRepository { get; }
    ILaptopRepository LaptopRepository { get; }
    //PC Components
    ICaseRepository CaseRepository { get; }
    ICPUCoolerRepository CPUCoolerRepository { get; }
    ICPURepository CPURepository { get; }
    IGPURepository GPURepository { get; }
    IHDDRepository HDDRepository { get; }
    IMotherboardRepository MotherboardRepository { get; }
    IPSURepository PSURepository { get; }
    IRAMRepository RAMRepository { get; }
    ISSDRepository SSDRepository { get; }
    //SmartDevices
    IDroneRepository DroneRepository { get; }
    ISmartPhoneRepository SmartPhoneRepository { get; }
}
