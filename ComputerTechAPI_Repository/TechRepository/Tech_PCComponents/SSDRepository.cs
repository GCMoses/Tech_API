using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class SSDRepository : RepositoryBase<SSD>, ISSDRepository
{
    public SSDRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<SSD>> GetSSDsAsync(Guid productId,
              SSDParams ssdParams, bool trackChanges)
    {
        var ssd = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterSSDs(ssdParams.MinRating, ssdParams.MaxRating)
        .Search(ssdParams.SearchTerm)
        //.Sort(ssdParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<SSD>(ssd, count,
        ssdParams.PageNumber, ssdParams.PageSize);
    }

    public async Task<SSD> GetSSDAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();


    public void CreateSSDForProduct(Guid productId, SSD ssd)
    {
        ssd.ProductId = productId;
        Create(ssd);
    }


    public void DeleteSSD(SSD ssd) => Delete(ssd);
}