using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_Contracts.ITech.ITech_Networking;
using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_Contracts.ITech;
using ComputerTechAPI_Repository.TechRepository;
using ComputerTechAPI_Repository.TechRepository.Tech_Accessories;
using ComputerTechAPI_Repository.TechRepository.Tech_Gaming;
using ComputerTechAPI_Repository.TechRepository.Tech_Networking;
using ComputerTechAPI_Repository.TechRepository.Tech_PC;
using ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;
using ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;


namespace ComputerTechAPI_Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IProductRepository> _productRepository;
    //Accessories
    private readonly Lazy<IGamingHeadphonesAndHeadsetRepository> _gamingHeadphonesAndHeadsetRepository;
    private readonly Lazy<IGamingKeyboardRepository> _gamingKeyboardRepository;
    private readonly Lazy<IGamingMouseRepository> _gamingMouseRepository;
    //Gaming
    private readonly Lazy<IGamingConsoleRepository> _gamingConsoleRepository;
    private readonly Lazy<IGamingDesktopRepository> _gamingDesktopRepository;
    private readonly Lazy<IGamingLaptopRepository> _gamingLaptopRepository;
    //Networking
    private readonly Lazy<IRouterRepository> _routerRepository;
    //PC
    private readonly Lazy<IDesktopRepository> _desktopRepository;
    private readonly Lazy<ILaptopRepository> _laptopRepository;
    //PC Components
    private readonly Lazy<ICaseRepository> _caseRepository;
    private readonly Lazy<ICPUCoolerRepository> _cpuCoolerRepository;
    private readonly Lazy<ICPURepository> _cpuRepository;
    private readonly Lazy<IGPURepository> _gpuRepository;
    private readonly Lazy<IHDDRepository> _hddRepository;
    private readonly Lazy<IMotherboardRepository> _motherboardRepository;
    private readonly Lazy<IRAMRepository> _ramRepository;
    private readonly Lazy<IPSURepository> _psuRepository;
    private readonly Lazy<ISSDRepository> _ssdRepository;
    //Smart Devices
    private readonly Lazy<IDroneRepository> _droneRepository;
    private readonly Lazy<ISmartPhoneRepository> _smartPhoneRepository;



    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            //Accessories
            _gamingHeadphonesAndHeadsetRepository = new Lazy<IGamingHeadphonesAndHeadsetRepository>(() => new
          GamingHeadphonesAndHeadsetRepository(repositoryContext));
        _gamingKeyboardRepository = new Lazy<IGamingKeyboardRepository>(() => new
       GamingKeyboardRepository(repositoryContext));
        _gamingMouseRepository = new Lazy<IGamingMouseRepository>(() => new
       GamingMouseRepository(repositoryContext));
        //Gaming
        _gamingConsoleRepository = new Lazy<IGamingConsoleRepository>(() => new
      GamingConsoleRepository(repositoryContext));
        _gamingDesktopRepository = new Lazy<IGamingDesktopRepository>(() => new
      GamingDesktopRepository(repositoryContext));
        _gamingLaptopRepository = new Lazy<IGamingLaptopRepository>(() => new
      GamingLaptopRepository(repositoryContext));
        //Networking
        _routerRepository = new Lazy<IRouterRepository>(() => new
      RouterRepository(repositoryContext));
        //PC
        _desktopRepository = new Lazy<IDesktopRepository>(() => new
      DesktopRepository(repositoryContext));
        _laptopRepository = new Lazy<ILaptopRepository>(() => new
      LaptopRepository(repositoryContext));
        //PC Components
        _caseRepository = new Lazy<ICaseRepository>(() => new
     CaseRepository(repositoryContext));
        _cpuCoolerRepository = new Lazy<ICPUCoolerRepository>(() => new
     CPUCoolerRepository(repositoryContext));
        _cpuRepository = new Lazy<ICPURepository>(() => new
     CPURepository(repositoryContext));
        _gpuRepository = new Lazy<IGPURepository>(() => new
     GPURepository(repositoryContext));
        _hddRepository = new Lazy<IHDDRepository>(() => new
     HDDRepository(repositoryContext));
        _motherboardRepository = new Lazy<IMotherboardRepository>(() => new
     MotherboardRepository(repositoryContext));
        _ramRepository = new Lazy<IRAMRepository>(() => new
     RAMRepository(repositoryContext));
        _psuRepository = new Lazy<IPSURepository>(() => new
     PSURepository(repositoryContext));
        _ssdRepository = new Lazy<ISSDRepository>(() => new
     SSDRepository(repositoryContext));
        //Smart Devices
        _droneRepository = new Lazy<IDroneRepository>(() => new
     DroneRepository(repositoryContext));
        _smartPhoneRepository = new Lazy<ISmartPhoneRepository>(() => new
     SmartPhoneRepository(repositoryContext));
    }
    //Accessories
    //Gaming
    //Networking
    //PC
    //PC Components
    //Smart Devices

    public IProductRepository Product => _productRepository.Value;

    public IGamingHeadphonesAndHeadsetRepository GamingHeadphonesAndHeadset => _gamingHeadphonesAndHeadsetRepository.Value;

    public IGamingKeyboardRepository GamingKeyboard => _gamingKeyboardRepository.Value;

    public IGamingMouseRepository GamingMouse => _gamingMouseRepository.Value;

    public IGamingConsoleRepository GamingConsole => _gamingConsoleRepository.Value;

    public IGamingDesktopRepository GamingDesktop => _gamingDesktopRepository.Value;

    public IGamingLaptopRepository GamingLaptop => _gamingLaptopRepository.Value;

    public IRouterRepository Router => _routerRepository.Value;

    public IDesktopRepository Desktop => _desktopRepository.Value;

    public ILaptopRepository Laptop => _laptopRepository.Value;

    public ICaseRepository Case => _caseRepository.Value;

    public ICPUCoolerRepository CPUCooler => _cpuCoolerRepository.Value;

    public ICPURepository CPU => _cpuRepository.Value;

    public IGPURepository GPU => _gpuRepository.Value;

    public IHDDRepository HDD => _hddRepository.Value;

    public IMotherboardRepository Motherboard => _motherboardRepository.Value;

    public IPSURepository PSU => _psuRepository.Value;

    public IRAMRepository RAM => _ramRepository.Value;

    public ISSDRepository SSD => _ssdRepository.Value;

    public IDroneRepository Drone => _droneRepository.Value;

    public ISmartPhoneRepository SmartPhone => _smartPhoneRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

}