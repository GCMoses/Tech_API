using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;
using ComputerTechAPI_Repository.Extensions.GamingExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Gaming;

public class GamingConsoleRepository : RepositoryBase<GamingConsole>, IGamingConsoleRepository
{
    public GamingConsoleRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    //Can be used to get large rows 100k-millions data and It's been tried and tested on large scale apps.  

    public async Task<PagedList<GamingConsole>> GetGamingConsolesAsync(Guid productId,
    GamingConsoleParams gamingConsoleParams, bool trackChanges)
    {
        var gamingConsoles = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterGamingConsoles(gamingConsoleParams.MinRating, gamingConsoleParams.MaxRating)
        .Search(gamingConsoleParams.SearchTerm)
        //.Sort(gamingConsoleParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GamingConsole>(gamingConsoles, count,
        gamingConsoleParams.PageNumber, gamingConsoleParams.PageSize);
    }

    public async Task<GamingConsole> GetGamingConsoleAsync(Guid productId, Guid id, bool trackChanges) =>
           await FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
           .SingleOrDefaultAsync();


    public void CreateGamingConsoleForProduct(Guid productId, GamingConsole gamingConsole)
    {
        gamingConsole.ProductId = productId;
        Create(gamingConsole);
    }


    public void DeleteGamingConsole(GamingConsole gamingConsole) => Delete(gamingConsole);

}