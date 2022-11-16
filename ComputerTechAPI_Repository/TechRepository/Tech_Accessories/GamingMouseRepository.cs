using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

public class GamingMouseRepository : RepositoryBase<GamingMouse>, IGamingMouseRepository
{
    public GamingMouseRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
