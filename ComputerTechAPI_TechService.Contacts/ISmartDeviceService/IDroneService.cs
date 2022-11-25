using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

public interface IDroneService
{
    IEnumerable<DroneDTO> GetDrones(Guid productId, bool trackChanges);

    DroneDTO GetDrone(Guid productId, Guid id, bool trackChanges);

    DroneDTO CreateDroneForProduct(Guid productId, DroneCreateDTO drone, bool trackChanges);

    void DeleteDroneForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateDroneForProduct(Guid productId, Guid id, DroneUpdateDTO droneUpdate,
                               bool productTrackChanges, bool droneTrackChanges);

    (DroneUpdateDTO droneToPatch, Drone droneEntity) GetDroneForPatch(
Guid productId, Guid id, bool productTrackChanges, bool droneTrackChanges);
    void SaveChangesForPatch(DroneUpdateDTO droneToPatch, Drone
    droneEntity);

}
