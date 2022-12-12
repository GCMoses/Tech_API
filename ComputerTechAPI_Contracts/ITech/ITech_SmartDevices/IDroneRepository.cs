using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;

public interface IDroneRepository
{
    Task<PagedList<Drone>> GetDronesAsync(Guid productId, DroneParams droneParams, bool trackChanges);

    Task<Drone> GetDroneAsync(Guid productId, Guid id, bool trackChanges);

    void CreateDroneForProduct(Guid productId, Drone drone);

    void DeleteDrone(Drone drone);
}
