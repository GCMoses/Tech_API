using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

public class GamingKeyboardRepository : RepositoryBase<GamingKeyboard>, IGamingKeyboardRepository
{
    public GamingKeyboardRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    //Can be used to get large rows 100k-millions data and It's been tried and tested on large scale apps.  

    public async Task<PagedList<GamingKeyboard>> GetGamingKeyboardsAsync(Guid productId,
    GamingKeyboardParams gamingKeyboardParams, bool trackChanges)
    {
        var gamingKeyboards = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterGamingKeyboards(gamingKeyboardParams.MinRating, gamingKeyboardParams.MaxRating)
        .Search(gamingKeyboardParams.SearchTerm)
        //.Sort(gamingKeyboardParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GamingKeyboard>(gamingKeyboards, count,
        gamingKeyboardParams.PageNumber, gamingKeyboardParams.PageSize);
    }

    public async Task<GamingKeyboard> GetGamingKeyboardAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(g => g.ProductId.Equals(productId) && g.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();



    public void CreateGamingKeyboardForProduct(Guid productId, GamingKeyboard gamingKeyboard)
    {
        gamingKeyboard.ProductId = productId;
        Create(gamingKeyboard);
    }

    public void DeleteGamingKeyboard(GamingKeyboard gamingKeyboard) => Delete(gamingKeyboard);


}