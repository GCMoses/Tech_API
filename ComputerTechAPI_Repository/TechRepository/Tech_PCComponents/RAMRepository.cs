using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class RAMRepository : RepositoryBase<RAM>, IRAMRepository
{
    public RAMRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<RAM>> GetRAMsAsync(Guid productId,
              RAMParams ramParams, bool trackChanges)
    {
        var ram = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterRAMs(ramParams.MinRating, ramParams.MaxRating)
        .Search(ramParams.SearchTerm)
        //.Sort(ramParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<RAM>(ram, count,
        ramParams.PageNumber, ramParams.PageSize);
    }

    public async Task<RAM> GetRAMAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRAMForProduct(Guid productId, RAM ram)
    {
        ram.ProductId = productId;
        Create(ram);
    }

    public void DeleteRAM(RAM ram) => Delete(ram);
}
