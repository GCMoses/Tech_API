using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Gaming;

public class GamingDesktopRepository : RepositoryBase<GamingDesktop>, IGamingDesktopRepository
{
    public GamingDesktopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<GamingDesktop> GetGamingDesktops(Guid productId, bool trackChanges) =>
          FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
         .OrderBy(g => g.Name)
         .ToList();


    public GamingDesktop GetGamingDesktop(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}