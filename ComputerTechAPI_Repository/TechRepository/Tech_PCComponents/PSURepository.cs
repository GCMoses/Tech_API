using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class PSURepository : RepositoryBase<PSU>, IPSURepository
{
    public PSURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
