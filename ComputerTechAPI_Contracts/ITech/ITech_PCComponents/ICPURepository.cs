using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICPURepository
{
    Task<PagedList<CPU>> GetCPUsAsync(Guid productId, CPUParams cpuParams, bool trackChanges);

    Task<CPU> GetCPUAsync(Guid productId, Guid id, bool trackChanges);

    void CreateCPUForProduct(Guid productId, CPU cpu);

    void DeleteCPU(CPU cpu);
}


