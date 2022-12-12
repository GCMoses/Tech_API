using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using Microsoft.EntityFrameworkCore;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;


namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

internal sealed class GamingHeadphonesAndHeadsetRepository : RepositoryBase<GamingHeadphonesAndHeadset>, IGamingHeadphonesAndHeadsetRepository
{
    public GamingHeadphonesAndHeadsetRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    //Can be used to get large rows 100k-millions data and It's been tried and tested on large scale apps.  

    public async Task<PagedList<GamingHeadphonesAndHeadset>> GetGamingHeadphonesAndHeadsetsAsync(Guid productId,
    GamingHeadphonesAndHeadsetParams gamingHeadphonesAndHeadsetParams, bool trackChanges)
    {
        var gamingHeadphonesAndHeadsets = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterGamingHeadphonesAndHeadsets(gamingHeadphonesAndHeadsetParams.MinRating, gamingHeadphonesAndHeadsetParams.MaxRating)
        .Search(gamingHeadphonesAndHeadsetParams.SearchTerm)
        //.Sort(gamingHeadphonesAndHeadsetParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GamingHeadphonesAndHeadset>(gamingHeadphonesAndHeadsets, count,
        gamingHeadphonesAndHeadsetParams.PageNumber, gamingHeadphonesAndHeadsetParams.PageSize);
    }

    public async Task<GamingHeadphonesAndHeadset> GetGamingHeadphonesAndHeadsetAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();



    public void CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset)
    {
        gamingHeadphonesAndHeadset.ProductId = productId;
        Create(gamingHeadphonesAndHeadset);
    }

    public void DeleteGamingHeadphonesAndHeadset(GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset) => Delete(gamingHeadphonesAndHeadset);


}
