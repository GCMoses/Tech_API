using ComputerTechAPI_TechService.Contracts.IAccessoriesService;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using ComputerTechAPI_TechService.Contracts.INetworkingService;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_TechService.Contracts.PCService;

namespace ComputerTechAPI_TechService.Contracts;

public interface IServiceManager
{
    IProductService ProductService { get; }
    //Accessories
    IGamingHeadphonesAndHeadsetService GamingHeadphonesAndHeadsetService { get; }
    IGamingKeyboardService GamingKeyboardService { get; }
    IGamingMouseService GamingMouseService { get; }
    //Gaming
    IGamingConsoleService GamingConsoleService { get; }
    IGamingDesktopService GamingDesktopService { get; }
    IGamingLaptopService GamingLaptopService { get; }
    //Networking
    IRouterService RouterService { get; }
    //PC
    IDesktopService DesktopService { get; }
    ILaptopService LaptopService { get; }
    //PC Components
    ICaseService CaseService { get; }
    ICPUCoolerService CPUCoolerService { get; }
    ICPUService CPUService { get; }
    IGPUService GPUService { get; }
    IHDDService HDDService { get; }
    IMotherboardService MotherboardService { get; }
    IPSUService PSUService { get; }
    IRAMService RAMService { get; }
    ISSDService SSDService { get; }
    //SmartDevices
    IDroneService DroneService { get; }
    ISmartPhoneService SmartPhoneService { get; }
}