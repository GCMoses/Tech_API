using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class CPURepository : RepositoryBase<CPU>, ICPURepository
{
    public CPURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<CPU>> GetCPUsAsync(Guid productId,
             CPUParams cpuParams, bool trackChanges)
    {
        var cpu = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterCPUs(cpuParams.MinRating, cpuParams.MaxRating)
        .Search(cpuParams.SearchTerm)
        //.Sort(cpuParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<CPU>(cpu, count,
        cpuParams.PageNumber, cpuParams.PageSize);
    }

    public async Task<CPU> GetCPUAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateCPUForProduct(Guid productId, CPU cpu)
    {
        cpu.ProductId = productId;
        Create(cpu);
    }
    public void DeleteCPU(CPU cpu) => Delete(cpu);
}