using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;
using ComputerTechAPI_Repository.Extensions.GamingExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Gaming;

public class GamingDesktopRepository : RepositoryBase<GamingDesktop>, IGamingDesktopRepository
{
    public GamingDesktopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    //Can be used to get large rows 100k-millions data and It's been tried and tested on large scale apps.  

    public async Task<PagedList<GamingDesktop>> GetGamingDesktopsAsync(Guid productId,
    GamingDesktopParams gamingDesktopParams, bool trackChanges)
    {
        var gamingDesktops = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterGamingDesktop(gamingDesktopParams.MinRating, gamingDesktopParams.MaxRating)
        .Search(gamingDesktopParams.SearchTerm)
        //.Sort(gamingDesktopParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GamingDesktop>(gamingDesktops, count,
        gamingDesktopParams.PageNumber, gamingDesktopParams.PageSize);
    }

    public async Task<GamingDesktop> GetGamingDesktopAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();


    public void CreateGamingDesktopForProduct(Guid productId, GamingDesktop gamingDesktop)
    {
        gamingDesktop.ProductId = productId;
        Create(gamingDesktop);
    }


    public void DeleteGamingDesktop(GamingDesktop gamingDesktop) => Delete(gamingDesktop);

    
}