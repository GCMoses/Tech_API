using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;
using ComputerTechAPI_Repository.Extensions.GamingExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Gaming;

public class GamingLaptopRepository : RepositoryBase<GamingLaptop>, IGamingLaptopRepository
{
    public GamingLaptopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    //Can be used to get large rows 100k-millions data and It's been tried and tested on large scale apps.  

    public async Task<PagedList<GamingLaptop>> GetGamingLaptopsAsync(Guid productId,
    GamingLaptopParams gamingLaptopParams, bool trackChanges)
    {
        var gamingLaptops = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterGamingLaptops(gamingLaptopParams.MinRating, gamingLaptopParams.MaxRating)
        .Search(gamingLaptopParams.SearchTerm)
        //.Sort(gamingLaptopParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GamingLaptop>(gamingLaptops, count,
        gamingLaptopParams.PageNumber, gamingLaptopParams.PageSize);
    }

    public async Task<GamingLaptop> GetGamingLaptopAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateGamingLaptopForProduct(Guid productId, GamingLaptop gamingLaptop)
    {
        gamingLaptop.ProductId = productId;
        Create(gamingLaptop);
    }


    public void DeleteGamingLaptop(GamingLaptop gamingLaptop) => Delete(gamingLaptop);
}