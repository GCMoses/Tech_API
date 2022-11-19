using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICPUService
{
    IEnumerable<CPUDTO> GetCPUs(Guid productId, bool trackChanges);

    CPUDTO GetCPU(Guid productId, Guid id, bool trackChanges);
}
