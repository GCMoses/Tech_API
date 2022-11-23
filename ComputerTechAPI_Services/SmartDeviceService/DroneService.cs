using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;

namespace ComputerTechAPI_Services.SmartDeviceService;

public class DroneService : IDroneService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public DroneService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<DroneDTO> GetDrones(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var droneDb = _repository.Drone.GetDrones(productId, trackChanges);
        var droneDTO = _mapper.Map<IEnumerable<DroneDTO>>(droneDb);
        return droneDTO;
    }


    public DroneDTO GetDrone(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var droneDb = _repository.Drone.GetDrone(productId, id, trackChanges);
        if (droneDb is null)
            throw new DroneNotFoundException(id);

        var drone = _mapper.Map<DroneDTO>(droneDb);
        return drone;
    }


    public DroneDTO CreateDroneForProduct(Guid productId, DroneCreateDTO droneCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var droneEntity = _mapper.Map<Drone>(droneCreate);
        _repository.Drone.CreateDroneForProduct(productId, droneEntity);
        _repository.Save();
        var droneToReturn = _mapper.Map<DroneDTO>(droneEntity);
        return droneToReturn;
    }


    public void DeleteDroneForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var droneForProduct = _repository.Drone.GetDrone(productId, id, trackChanges);
        if (droneForProduct is null)
            throw new DroneNotFoundException(id);
        _repository.Drone.DeleteDrone(droneForProduct);
        _repository.Save();
    }


    public void UpdateDroneForProduct(Guid productId, Guid id, DroneUpdateDTO droneUpdate,
                                  bool productTrackChanges, bool droneTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var droneEntity = _repository.Drone.GetDrone(productId, id,
        droneTrackChanges);
        if (droneEntity is null)
            throw new DroneNotFoundException(id);
        _mapper.Map(droneUpdate, droneEntity);
        _repository.Save();
    }
}