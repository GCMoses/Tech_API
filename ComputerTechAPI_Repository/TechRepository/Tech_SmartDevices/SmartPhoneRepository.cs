using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;

public class SmartPhoneRepository : RepositoryBase<Drone>, ISmartPhoneRepository
{
    public SmartPhoneRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}