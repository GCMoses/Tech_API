using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingKeyboardService
{
    IEnumerable<GamingKeyboardDTO> GetGamingKeyboards(Guid productId, bool trackChanges);
    GamingKeyboardDTO GetGamingKeyboard(Guid productId, Guid id, bool trackChanges);
}
