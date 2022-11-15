using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTech_Repository.TechRepository.Tech_PCComponents;

public class RAMRepository : RepositoryBase<RAM>, IRAMRepository
{
    public RAMRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
