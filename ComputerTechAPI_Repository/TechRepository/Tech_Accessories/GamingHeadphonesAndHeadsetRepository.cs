using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

internal sealed class GamingHeadphonesAndHeadsetRepository : RepositoryBase<GamingHeadphonesAndHeadset>, IGamingHeadphonesAndHeadsetRepository
{
    public GamingHeadphonesAndHeadsetRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }


    public IEnumerable<GamingHeadphonesAndHeadset> GetGamingHeadphonesAndHeadsets(Guid productId, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        .OrderBy(g => g.Name)
        .ToList();

    public GamingHeadphonesAndHeadset GetGamingHeadphonesAndHeadset(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
    .SingleOrDefault();

    public void CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset)
    {
        gamingHeadphonesAndHeadset.ProductId = productId;
        Create(gamingHeadphonesAndHeadset);
    }

    public void DeleteGamingHeadphonesAndHeadset(GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset) => Delete(gamingHeadphonesAndHeadset);


}
