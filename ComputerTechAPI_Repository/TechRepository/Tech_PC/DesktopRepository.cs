using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Repository.Extensions.PCExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PC;

public class DesktopRepository : RepositoryBase<Desktop>, IDesktopRepository
{
    public DesktopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<Desktop>> GetDesktopsAsync(Guid productId,
            DesktopParams desktopParams, bool trackChanges)
    {
        var desktop = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterDesktops(desktopParams.MinRating, desktopParams.MaxRating)
        .Search(desktopParams.SearchTerm)
        //.Sort(desktopParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<Desktop>(desktop, count,
        desktopParams.PageNumber, desktopParams.PageSize);
    }

    public async Task<Desktop> GetDesktopAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();


    public void CreateDesktopForProduct(Guid productId, Desktop desktop)
    {
        desktop.ProductId = productId;
        Create(desktop);

    }

        public void DeleteDesktop(Desktop desktop) => Delete(desktop);
}