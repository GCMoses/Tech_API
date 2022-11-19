using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICaseService
{
    IEnumerable<CaseDTO> GetCases(Guid productId, bool trackChanges);

    CaseDTO GetCase(Guid productId, Guid id, bool trackChanges);
}
