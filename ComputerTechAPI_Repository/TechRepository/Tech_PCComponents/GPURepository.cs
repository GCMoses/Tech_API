using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;
public class GPURepository : RepositoryBase<GPU>, IGPURepository
{
    public GPURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
