using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class PSURepository : RepositoryBase<PSU>, IPSURepository
{
    public PSURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public async Task<PagedList<PSU>> GetPSUsAsync(Guid productId,
               PSUParams psuParams, bool trackChanges)
    {
        var psu = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterPSUs(psuParams.MinRating, psuParams.MaxRating)
        .Search(psuParams.SearchTerm)
        //.Sort(psuParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<PSU>(psu, count,
        psuParams.PageNumber, psuParams.PageSize);
    }

    public async Task<PSU> GetPSUAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreatePSUForProduct(Guid productId, PSU psu)
    {
        psu.ProductId = productId;
        Create(psu);
    }


    public void DeletePSU(PSU psu) => Delete(psu);
}
