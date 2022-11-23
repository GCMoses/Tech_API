using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICPUCoolerRepository
{
    IEnumerable<CPUCooler> GetCPUCoolers(Guid productId, bool trackChanges);

    CPUCooler GetCPUCooler(Guid productId, Guid id, bool trackChanges);

    void CreateCPUCoolerForProduct(Guid productId, CPUCooler cpuCooler);

    void DeleteCPUCooler(CPUCooler cpuCooler);
}
