using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingKeyboardService
{
    IEnumerable<GamingKeyboardDTO> GetGamingKeyboards(Guid productId, bool trackChanges);
    GamingKeyboardDTO GetGamingKeyboard(Guid productId, Guid id, bool trackChanges);

    GamingKeyboardDTO CreateGamingKeyboardForProduct(Guid productId, GamingKeyboardCreateDTO gamingKeyboardCreate, bool trackChanges);

    void DeleteGamingKeyboardForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateGamingKeyboardForProduct(Guid productId, Guid id, GamingKeyboardUpdateDTO gamingKeyboardUpdate,
                                       bool productTrackChanges, bool gamingKeyboardTrackChanges);
}
