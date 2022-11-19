using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Gaming;

public class GamingConsoleRepository : RepositoryBase<GamingConsole>, IGamingConsoleRepository
{
    public GamingConsoleRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<GamingConsole> GetGamingConsoles(Guid productId, bool trackChanges) =>
          FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
         .OrderBy(g => g.Name)
         .ToList();


    public GamingConsole GetGamingConsole(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}