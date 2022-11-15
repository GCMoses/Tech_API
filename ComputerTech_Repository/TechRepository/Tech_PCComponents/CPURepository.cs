using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTech_Repository.TechRepository.Tech_PCComponents;

public class CPURepository : RepositoryBase<CPU>, ICPURepository
{
    public CPURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}