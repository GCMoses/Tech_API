using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

public interface IDroneService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetDronesAsync(Guid productId,
        DroneLinkParameters linkParameters, bool trackChanges);
    Task<DroneDTO> GetDroneAsync(Guid productId, Guid id, bool trackChanges);
    Task<DroneDTO> CreateDroneForProductAsync(Guid productId,
       DroneCreateDTO droneCreate, bool trackChanges);
    Task DeleteDroneForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateDroneForProductAsync(Guid productId, Guid id,
        DroneUpdateDTO droneUpdate, bool productTrackChanges, bool droneTrackChanges);
    Task<(DroneUpdateDTO droneToPatch, Drone droneEntity)> GetDroneForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool droneTrackChanges);
    Task SaveChangesForPatchAsync(DroneUpdateDTO DroneToPatch, Drone droneEntity);
}

