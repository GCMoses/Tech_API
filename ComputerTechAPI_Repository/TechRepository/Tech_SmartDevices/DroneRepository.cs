using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;

public class DroneRepository : RepositoryBase<Drone>, IDroneRepository
{
    public DroneRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
