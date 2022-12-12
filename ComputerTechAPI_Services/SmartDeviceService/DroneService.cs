using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;
using ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;

namespace ComputerTechAPI_Services.SmartDeviceService;

public class DroneService : IDroneService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IDroneLinks _droneLinks;
    public DroneService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IDroneLinks droneLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _droneLinks = droneLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetDronesAsync(Guid productId, DroneLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.droneParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var dronesWithMetaData = await _repository.Drone
        .GetDronesAsync(productId, linkParameters.droneParams, trackChanges);

        var dronesDTO = _mapper.Map<IEnumerable<DroneDTO>>
            (dronesWithMetaData);
        var links = _droneLinks.TryGenerateLinks(dronesDTO,
        linkParameters.droneParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: dronesWithMetaData.MetaData);
    }
    public async Task<DroneDTO> GetDroneAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var droneDb = await GetDroneForProductAndCheckIfItExists(productId, id, trackChanges);

        var droneDTO = _mapper.Map<DroneDTO>(droneDb);
        return droneDTO;
    }

    public async Task<DroneDTO> CreateDroneForProductAsync(Guid productId,
        DroneCreateDTO droneCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var droneEntity = _mapper.Map<Drone>(droneCreate);

        _repository.Drone.CreateDroneForProduct(productId, droneEntity);
        await _repository.SaveAsync();

        var droneToReturn = _mapper.Map<DroneDTO>(droneEntity);

        return droneToReturn;
    }

    public async Task DeleteDroneForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var droneDb = await GetDroneForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.Drone.DeleteDrone(droneDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateDroneForProductAsync(Guid productId, Guid id, DroneUpdateDTO
        droneUpdate, bool productTrackChanges, bool droneTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var droneDb = await GetDroneForProductAndCheckIfItExists(productId, id, droneTrackChanges);

        _mapper.Map(droneUpdate, droneDb);
        await _repository.SaveAsync();
    }

    public async Task<(DroneUpdateDTO droneToPatch, Drone droneEntity)> GetDroneForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool droneTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var droneDb = await GetDroneForProductAndCheckIfItExists(productId, id, droneTrackChanges);

        var droneToPatch = _mapper.Map<DroneUpdateDTO>(droneDb);

        return (droneToPatch: droneToPatch, droneEntity: droneDb);
    }

    public async Task SaveChangesForPatchAsync(DroneUpdateDTO droneToPatch, Drone droneEntity)
    {
        _mapper.Map(droneToPatch, droneEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<Drone> GetDroneForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var droneDb = await _repository.Drone.GetDroneAsync(productId, id, trackChanges);
        if (droneDb is null)
            throw new DroneNotFoundException(id);

        return droneDb;
    }
}
