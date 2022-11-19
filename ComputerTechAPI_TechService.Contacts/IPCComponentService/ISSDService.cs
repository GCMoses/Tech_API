using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ISSDService
{
    IEnumerable<SSDDTO> GetSSDs(Guid productId, bool trackChanges);

    SSDDTO GetSSD(Guid productId, Guid id, bool trackChanges);
}
