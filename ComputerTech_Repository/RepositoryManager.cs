using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_Contracts.ITech.ITech_Networking;
using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_Contracts.ITech;
using ComputerTech_Repository.TechRepository;
using ComputerTech_Repository.TechRepository.Tech_Accessories;
using ComputerTech_Repository.TechRepository.Tech_Gaming;
using ComputerTech_Repository.TechRepository.Tech_PC;
using ComputerTech_Repository.TechRepository.Tech_PCComponents;
using ComputerTech_Repository.TechRepository.Tech_SmartDevices;
using ComputerTech_Repository.TechRepository.Tech_Networking;

namespace ComputerTech_Repository;

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
        _productRepository = new Lazy<IProductRepository>(() => new
            ProductRepository(repositoryContext));
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
    public IProductRepository ProductRepository => _productRepository.Value;
    //Accessories
    public IGamingHeadphonesAndHeadsetRepository GamingHeadphonesAndHeadsetRepository => _gamingHeadphonesAndHeadsetRepository.Value;
    public IGamingKeyboardRepository GamingKeyboardRepository => _gamingKeyboardRepository.Value;
    public IGamingMouseRepository GamingMouseRepository => _gamingMouseRepository.Value;
    //Gaming
    public IGamingConsoleRepository GamingConsoleRepository => _gamingConsoleRepository.Value;
    public IGamingDesktopRepository GamingDesktopRepository => _gamingDesktopRepository.Value;
    public IGamingLaptopRepository GamingLaptopRepository => _gamingLaptopRepository.Value;
    //Networking
    public IRouterRepository RouterRepository => _routerRepository.Value;
    //PC
    public IDesktopRepository DesktopRepository => _desktopRepository.Value;
    public ILaptopRepository LaptopRepository => _laptopRepository.Value;
    //PC Components
    public ICaseRepository CaseRepository => _caseRepository.Value;
    public ICPUCoolerRepository CPUCoolerRepository => _cpuCoolerRepository.Value;
    public ICPURepository CPURepository => _cpuRepository.Value;
    public IGPURepository GPURepository => _gpuRepository.Value;
    public IHDDRepository HDDRepository => _hddRepository.Value;
    public IMotherboardRepository MotherboardRepository => _motherboardRepository.Value;
    public IRAMRepository RAMRepository => _ramRepository.Value;
    public IPSURepository PSURepository => _psuRepository.Value;
    public ISSDRepository SSDRepository => _ssdRepository.Value;
    //Smart Devices
    public IDroneRepository DroneRepository => _droneRepository.Value;
    public ISmartPhoneRepository SmartPhoneRepository => _smartPhoneRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
}