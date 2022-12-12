using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class HDDRepository : RepositoryBase<HDD>, IHDDRepository
{
    public HDDRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public async Task<PagedList<HDD>> GetHDDsAsync(Guid productId,
              HDDParams hddParams, bool trackChanges)
    {
        var hdd = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterHDDs(hddParams.MinRating, hddParams.MaxRating)
        .Search(hddParams.SearchTerm)
        //.Sort(hddParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<HDD>(hdd, count,
        hddParams.PageNumber, hddParams.PageSize);
    }
    public async Task<HDD> GetHDDAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateHDDForProduct(Guid productId, HDD hdd)
    {
        hdd.ProductId = productId;
        Create(hdd);
    }


    public void DeleteHDD(HDD hdd) => Delete(hdd);
}
