using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICPUCoolerRepository
{
    Task<PagedList<CPUCooler>> GetCPUCoolersAsync(Guid productId,
        CPUCoolerParams cpuCoolerParams, bool trackChanges);

    Task<CPUCooler> GetCPUCoolerAsync(Guid productId, Guid id, bool trackChanges);

    void CreateCPUCoolerForProduct(Guid productId, CPUCooler cpuCooler);

    void DeleteCPUCooler(CPUCooler cpuCooler);
}
