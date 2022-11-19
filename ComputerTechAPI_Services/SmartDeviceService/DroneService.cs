using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;

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
}