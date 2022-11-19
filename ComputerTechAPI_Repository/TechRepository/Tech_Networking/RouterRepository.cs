using ComputerTechAPI_Contracts.ITech.ITech_Networking;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Networking;

public class RouterRepository : RepositoryBase<Router>, IRouterRepository
{
    public RouterRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<Router> GetRouters(Guid productId, bool trackChanges) =>
         FindByCondition(r => r.ProductId.Equals(productId), trackChanges)
        .OrderBy(r => r.Name)
        .ToList();


    public Router GetRouter(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(r => r.ProductId.Equals(productId) && r.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}
