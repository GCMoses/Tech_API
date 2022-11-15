using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTech_Repository.TechRepository.Tech_PCComponents;

public class HDDRepository : RepositoryBase<HDD>, IHDDRepository
{
    public HDDRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
