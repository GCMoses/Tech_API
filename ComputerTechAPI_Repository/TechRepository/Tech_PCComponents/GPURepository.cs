using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;
public class GPURepository : RepositoryBase<GPU>, IGPURepository
{
    public GPURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<GPU>> GetGPUsAsync(Guid productId,
              GPUParams gpuParams, bool trackChanges)
    {
        var gpu = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterGPUs(gpuParams.MinRating, gpuParams.MaxRating)
        .Search(gpuParams.SearchTerm)
        //.Sort(gpuParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<GPU>(gpu, count,
        gpuParams.PageNumber, gpuParams.PageSize);
    }

    public async Task<GPU> GetGPUAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateGPUForProduct(Guid productId, GPU gpu)
    {
        gpu.ProductId = productId;
        Create(gpu);
    }

    public void DeleteGPU(GPU gpu) => Delete(gpu);
}
