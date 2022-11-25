using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICPUCoolerService
{
    IEnumerable<CPUCoolerDTO> GetCPUCoolers(Guid productId, bool trackChanges);

    CPUCoolerDTO GetCPUCooler(Guid productId, Guid id, bool trackChanges);

    CPUCoolerDTO CreateCPUCoolerForProduct(Guid productId, CPUCoolerCreateDTO cpuCoolerCreate, bool trackChanges);

    void DeleteCPUCoolerForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateCPUCoolerForProduct(Guid productId, Guid id, CPUCoolerUpdateDTO cpuCoolerUpdate,
                                bool productTrackChanges, bool cpuCoolerTrackChanges);


    (CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler cpuCoolerEntity) GetCPUCoolerForPatch(
Guid productId, Guid id, bool productTrackChanges, bool cpuCoolerTrackChanges);
    void SaveChangesForPatch(CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler
    cpuCoolerEntity);
}
