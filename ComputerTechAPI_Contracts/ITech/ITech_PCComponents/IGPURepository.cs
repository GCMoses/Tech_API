using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IGPURepository
{
    IEnumerable<GPU> GetGPUs(Guid productId, bool trackChanges);

    GPU GetGPU(Guid productId, Guid id, bool trackChanges);

    void CreateGPUForProduct(Guid productId, GPU cpu);

    void DeleteGPU(GPU gpu);
}
