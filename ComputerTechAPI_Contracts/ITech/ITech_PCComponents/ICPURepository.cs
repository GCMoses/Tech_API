using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICPURepository
{
    IEnumerable<CPU> GetCPUs(Guid productId, bool trackChanges);

    CPU GetCPU(Guid productId, Guid id, bool trackChanges);

    void CreateCPUForProduct(Guid productId, CPU cpu);

    void DeleteCPU(CPU cpu);
}


