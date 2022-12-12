using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class CPUCoolerRepository : RepositoryBase<CPUCooler>, ICPUCoolerRepository
{
    public CPUCoolerRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<CPUCooler>> GetCPUCoolersAsync(Guid productId,
             CPUCoolerParams cpuCoolerParams, bool trackChanges)
    {
        var cpuCooler = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterCPUCoolers(cpuCoolerParams.MinRating, cpuCoolerParams.MaxRating)
        .Search(cpuCoolerParams.SearchTerm)
        //.Sort(cpuCoolerParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<CPUCooler>(cpuCooler, count,
        cpuCoolerParams.PageNumber, cpuCoolerParams.PageSize);
    }

    public async Task<CPUCooler> GetCPUCoolerAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateCPUCooler(CPUCooler cpuCooler) => Create(cpuCooler);
    public void CreateCPUCoolerForProduct(Guid productId, CPUCooler cpuCooler)
    {
        cpuCooler.ProductId = productId;
        Create(cpuCooler);
    }


    public void DeleteCPUCooler(CPUCooler cpuCooler) => Delete(cpuCooler);
}
