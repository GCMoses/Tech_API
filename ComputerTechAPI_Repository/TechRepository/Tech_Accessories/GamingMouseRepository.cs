using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

public class GamingMouseRepository : RepositoryBase<GamingMouse>, IGamingMouseRepository
{
    public GamingMouseRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<GamingMouse> GetGamingMouses(Guid productId, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
       .OrderBy(g => g.Name)
       .ToList();


    public GamingMouse GetGamingMouse(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}
