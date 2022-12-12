using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_Entities.ConfigurationModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Extensions.Options;
using ComputerTechAPI_Services.AccessoriesService;
using ComputerTechAPI_Services.GamingService;
using ComputerTechAPI_Services.NetworkingService;
using ComputerTechAPI_Services.PCComponentService;
using ComputerTechAPI_Services.PCService;
using ComputerTechAPI_Services.SmartDeviceService;
using ComputerTechAPI_TechService.Contracts;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;
using Microsoft.AspNetCore.Identity;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using ComputerTechAPI_TechService.Contracts.INetworkingService;
using ComputerTechAPI_Contracts.ILinks.INetworkingLinks;
using ComputerTechAPI_Contracts.ILinks.IPCLinks;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_TechService.Contracts.PCService;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;

namespace ComputerTechAPI_Services;

//Here, as I did with the RepositoryManager class, I'm using the
//Lazy class to ensure the lazy initialization of Tech's services.

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> _productService;
    //Accessories
    private readonly Lazy<IGamingHeadphonesAndHeadsetService> _gamingHeadphonesAndHeadsetService;
    private readonly Lazy<IGamingKeyboardService> _gamingKeyboardService;
    private readonly Lazy<IGamingMouseService> _gamingMouseService;
    ////Gaming
    private readonly Lazy<IGamingConsoleService> _gamingConsoleService;
    private readonly Lazy<IGamingDesktopService> _gamingDesktopService;
    private readonly Lazy<IGamingLaptopService> _gamingLaptopService;
    //Networking
    private readonly Lazy<IRouterService> _routerService;
    //PC
    private readonly Lazy<IDesktopService> _desktopService;
    private readonly Lazy<ILaptopService> _laptopService;
    //PC Components
    private readonly Lazy<ICaseService> _caseService;
    private readonly Lazy<ICPUCoolerService> _cpuCoolerService;
    private readonly Lazy<ICPUService> _cpuService;
    private readonly Lazy<IGPUService> _gpuService;
    private readonly Lazy<IHDDService> _hddService;
    private readonly Lazy<IMotherboardService> _motherboardService;
    private readonly Lazy<IPSUService> _psuService;
    private readonly Lazy<IRAMService> _ramService;
    private readonly Lazy<ISSDService> _ssdService;
    //Smart Device
    private readonly Lazy<IDroneService> _droneService;
    private readonly Lazy<ISmartPhoneService> _smartPhoneService;

    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager, ILogsManager logger, IMapper mapper, IGamingHeadphonesAndHeadsetLinks 
        gamingHeadphonesAndHeadsetLinks, IGamingKeyboardLinks gamingKeyboardLinks, IGamingMouseLinks gamingMouseLinks, 
        IGamingConsoleLinks gamingConsoleLinks, IGamingDesktopLinks gamingDesktopLinks, IGamingLaptopLinks gamingLaptopLinks,
        IRouterLinks routerLinks, IDesktopLinks desktopLinks, ILaptopLinks laptopLinks, ICaseLinks pcCaseLinks, ICPULinks cpuLinks,
        ICPUCoolerLinks cpuCoolerLinks, IGPULinks gpuLinks, IHDDLinks hddLinks, IMotherboardLinks motherboardLinks, 
        IPSULinks psuLinks, IRAMLinks ramLinks, ISSDLinks ssdLinks, IDroneLinks droneLinks, ISmartPhoneLinks smartPhoneLinks,
        UserManager<User> userManager, IOptions<JwtConfiguration> configuration)


    {
        _productService = new Lazy<IProductService>(() => new
        ProductService(repositoryManager, logger, mapper));
        //Accessories
        _gamingHeadphonesAndHeadsetService = new Lazy<IGamingHeadphonesAndHeadsetService>(() => new
      GamingHeadphonesAndHeadsetService(repositoryManager, logger, mapper, gamingHeadphonesAndHeadsetLinks));
        _gamingKeyboardService = new Lazy<IGamingKeyboardService>(() => new
       GamingKeyboardService(repositoryManager, logger, mapper, gamingKeyboardLinks));
        _gamingMouseService = new Lazy<IGamingMouseService>(() => new
       GamingMouseService(repositoryManager, logger, mapper, gamingMouseLinks));
        //Gaming
        _gamingConsoleService = new Lazy<IGamingConsoleService>(() => new
      GamingConsoleService(repositoryManager, logger, mapper, gamingConsoleLinks));
        _gamingDesktopService = new Lazy<IGamingDesktopService>(() => new
      GamingDesktopService(repositoryManager, logger, mapper, gamingDesktopLinks));
        _gamingLaptopService = new Lazy<IGamingLaptopService>(() => new
      GamingLaptopService(repositoryManager, logger, mapper, gamingLaptopLinks));
        //Networking
        _routerService = new Lazy<IRouterService>(() => new
      RouterService(repositoryManager, logger, mapper, routerLinks));
        //PC
        _desktopService = new Lazy<IDesktopService>(() => new
      DesktopService(repositoryManager, logger, mapper, desktopLinks));
        _laptopService = new Lazy<ILaptopService>(() => new
      LaptopService(repositoryManager, logger, mapper, laptopLinks));
        //PC Components
        _caseService = new Lazy<ICaseService>(() => new
     CaseService(repositoryManager, logger, mapper, pcCaseLinks));
        _cpuCoolerService = new Lazy<ICPUCoolerService>(() => new
     CPUCoolerService(repositoryManager, logger, mapper, cpuCoolerLinks));
        _cpuService = new Lazy<ICPUService>(() => new
     CPUService(repositoryManager, logger, mapper, cpuLinks));
        _gpuService = new Lazy<IGPUService>(() => new
     GPUService(repositoryManager, logger, mapper, gpuLinks));
        _hddService = new Lazy<IHDDService>(() => new
     HDDService(repositoryManager, logger, mapper, hddLinks));
        _motherboardService = new Lazy<IMotherboardService>(() => new
     MotherboardService(repositoryManager, logger, mapper, motherboardLinks));
        _ramService = new Lazy<IRAMService>(() => new
     RAMService(repositoryManager, logger, mapper, ramLinks));
        _psuService = new Lazy<IPSUService>(() => new
     PSUService(repositoryManager, logger, mapper, psuLinks));
        _ssdService = new Lazy<ISSDService>(() => new
     SSDService(repositoryManager, logger, mapper, ssdLinks));
        //Smart Devices
        _droneService = new Lazy<IDroneService>(() => new
     DroneService(repositoryManager, logger, mapper, droneLinks));
        _smartPhoneService = new Lazy<ISmartPhoneService>(() => new
     SmartPhoneService(repositoryManager, logger, mapper, smartPhoneLinks));
        //Auth
        _authenticationService = new Lazy<IAuthenticationService>(() =>new 
        AuthenticationService(logger, mapper, userManager, configuration));

    }

    public IProductService ProductService => _productService.Value;

    public IGamingHeadphonesAndHeadsetService GamingHeadphonesAndHeadsetService => _gamingHeadphonesAndHeadsetService.Value;

    public IGamingKeyboardService GamingKeyboardService => _gamingKeyboardService.Value;

    public IGamingMouseService GamingMouseService => _gamingMouseService.Value;

    public IGamingConsoleService GamingConsoleService => _gamingConsoleService.Value;

    public IGamingDesktopService GamingDesktopService => _gamingDesktopService.Value;

    public IGamingLaptopService GamingLaptopService => _gamingLaptopService.Value;

    public IRouterService RouterService => _routerService.Value;

    public IDesktopService DesktopService => _desktopService.Value;

    public ILaptopService LaptopService => _laptopService.Value;

    public ICaseService CaseService => _caseService.Value;

    public ICPUCoolerService CPUCoolerService => _cpuCoolerService.Value;

    public ICPUService CPUService => _cpuService.Value;

    public IGPUService GPUService => _gpuService.Value;

    public IHDDService HDDService => _hddService.Value;

    public IMotherboardService MotherboardService => _motherboardService.Value;

    public IPSUService PSUService => _psuService.Value;

    public IRAMService RAMService => _ramService.Value;

    public ISSDService SSDService => _ssdService.Value;

    public IDroneService DroneService => _droneService.Value;

    public ISmartPhoneService SmartPhoneService => _smartPhoneService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}

