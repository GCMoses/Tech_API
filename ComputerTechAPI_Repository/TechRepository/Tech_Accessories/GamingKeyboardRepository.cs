using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

public class GamingKeyboardRepository : RepositoryBase<GamingKeyboard>, IGamingKeyboardRepository
{
    public GamingKeyboardRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<GamingKeyboard> GetGamingKeyboards(Guid productId, bool trackChanges) =>
         FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        .OrderBy(g => g.Name)
        .ToList();


    public GamingKeyboard GetGamingKeyboard(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefault();


    public void CreateGamingKeyboardForProduct(Guid productId, GamingKeyboard gamingKeyboard)
    {
        gamingKeyboard.ProductId = productId;
        Create(gamingKeyboard);
    }

    public void DeleteGamingKeyboard(GamingKeyboard gamingKeyboard) => Delete(gamingKeyboard);
}
