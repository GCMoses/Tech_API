using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingKeyboardService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGamingKeyboardsAsync(Guid productId,
       GamingKeyboardLinkParameters linkParameters, bool trackChanges);
    Task<GamingKeyboardDTO> GetGamingKeyboardAsync(Guid productId, Guid id, bool trackChanges);
    Task<GamingKeyboardDTO> CreateGamingKeyboardForProductAsync(Guid productId,
        GamingKeyboardCreateDTO gamingKeyboardCreate, bool trackChanges);
    Task DeleteGamingKeyboardForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGamingKeyboardForProductAsync(Guid productId, Guid id,
        GamingKeyboardUpdateDTO gamingKeyboardUpdate, bool productTrackChanges, bool gamingKeyboardTrackChanges);
    Task<(GamingKeyboardUpdateDTO gamingKeyboardToPatch, GamingKeyboard gamingKeyboardEntity)> GetGamingKeyboardForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool gamingKeyboardTrackChanges);
    Task SaveChangesForPatchAsync(GamingKeyboardUpdateDTO gamingKeyboardToPatch, GamingKeyboard gamingKeyboardEntity);
}
