using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IGPURepository
{
    Task<PagedList<GPU>> GetGPUsAsync(Guid productId, GPUParams gpuParams, bool trackChanges);

    Task<GPU> GetGPUAsync(Guid productId, Guid id, bool trackChanges);

    void CreateGPUForProduct(Guid productId, GPU cpu);

    void DeleteGPU(GPU gpu);
}
