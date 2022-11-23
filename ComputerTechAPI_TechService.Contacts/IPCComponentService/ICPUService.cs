using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICPUService
{
    IEnumerable<CPUDTO> GetCPUs(Guid productId, bool trackChanges);

    CPUDTO GetCPU(Guid productId, Guid id, bool trackChanges);

    CPUDTO CreateCPUForProduct(Guid productId, CPUCreateDTO cpuCreate, bool trackChanges);

    void DeleteCPUForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateCPUForProduct(Guid productId, Guid id, CPUUpdateDTO cpuUpdate,
                                bool productTrackChanges, bool cpuTrackChanges);
}
