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
    IProductRepository Product { get; }
    //Accessories
    IGamingHeadphonesAndHeadsetRepository GamingHeadphonesAndHeadset { get; }
    IGamingKeyboardRepository GamingKeyboard { get; }
    IGamingMouseRepository GamingMouse{ get; }
    //Gaming
    IGamingConsoleRepository GamingConsole { get; }
    IGamingDesktopRepository GamingDesktop { get; }
    IGamingLaptopRepository GamingLaptop { get; }
    //Networking
    IRouterRepository Router { get; }
    //PC
    IDesktopRepository Desktop { get; }
    ILaptopRepository Laptop { get; }
    //PC Components
    ICaseRepository Case { get; }
    ICPUCoolerRepository CPUCooler { get; }
    ICPURepository CPU { get; }
    IGPURepository GPU { get; }
    IHDDRepository HDD { get; }
    IMotherboardRepository Motherboard { get; }
    IPSURepository PSU { get; }
    IRAMRepository RAM { get; }
    ISSDRepository SSD { get; }
    //SmartDevices
    IDroneRepository Drone { get; }
    ISmartPhoneRepository SmartPhone { get; }
    void Save();
}
