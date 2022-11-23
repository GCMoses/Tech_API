using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;
public class GPURepository : RepositoryBase<GPU>, IGPURepository
{
    public GPURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<GPU> GetGPUs(Guid productId, bool trackChanges) =>
       FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
      .OrderBy(c => c.Name)
      .ToList();


    public GPU GetGPU(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateGPUForProduct(Guid productId, GPU gpu)
    {
        gpu.ProductId = productId;
        Create(gpu);
    }

    public void DeleteGPU(GPU gpu) => Delete(gpu);
}
