using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IPSUService
{
    IEnumerable<PSUDTO> GetPSUs(Guid productId, bool trackChanges);

    PSUDTO GetPSU(Guid productId, Guid id, bool trackChanges);
}
