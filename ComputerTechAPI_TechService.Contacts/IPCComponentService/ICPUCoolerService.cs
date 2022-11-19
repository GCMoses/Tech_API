using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICPUCoolerService
{
    IEnumerable<CPUCoolerDTO> GetCPUCoolers(Guid productId, bool trackChanges);

    CPUCoolerDTO GetCPUCooler(Guid productId, Guid id, bool trackChanges);
}
