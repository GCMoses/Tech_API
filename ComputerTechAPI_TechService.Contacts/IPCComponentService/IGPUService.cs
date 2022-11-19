using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IGPUService
{
    IEnumerable<GPUDTO> GetGPUs(Guid productId, bool trackChanges);

    GPUDTO GetGPU(Guid productId, Guid id, bool trackChanges);
}
