using ComputerTechAPI_Contracts.ITech.ITech_Networking;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTech_Repository.TechRepository.Tech_Networking;

public class RouterRepository : RepositoryBase<Router>, IRouterRepository
{
    public RouterRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}