using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

public class GamingMouseRepository : RepositoryBase<GamingMouse>, IGamingMouseRepository
{
    public GamingMouseRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    //Can be used to get large rows 100k-millions data and It's been tried and tested on large scale apps.  

    public async Task<PagedList<GamingMouse>> GetGamingMousesAsync(Guid productId,
    GamingMouseParams gamingMouseParams, bool trackChanges)
    {
        var gamingMouses = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterGamingMouses(gamingMouseParams.MinRating, gamingMouseParams.MaxRating)
        .Search(gamingMouseParams.SearchTerm)
        //.Sort(gamingMouseParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GamingMouse>(gamingMouses, count,
        gamingMouseParams.PageNumber, gamingMouseParams.PageSize);
    }

    public async Task<GamingMouse> GetGamingMouseAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();



    public void CreateGamingMouseForProduct(Guid productId, GamingMouse gamingMouse)
    {
        gamingMouse.ProductId = productId;
        Create(gamingMouse);
    }

    public void DeleteGamingMouse(GamingMouse gamingMouse) => Delete(gamingMouse);


}