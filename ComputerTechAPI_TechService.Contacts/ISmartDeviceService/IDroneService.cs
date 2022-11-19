using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;

namespace ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

public interface IDroneService
{
    IEnumerable<DroneDTO> GetDrones(Guid productId, bool trackChanges);

    DroneDTO GetDrone(Guid productId, Guid id, bool trackChanges);
}
