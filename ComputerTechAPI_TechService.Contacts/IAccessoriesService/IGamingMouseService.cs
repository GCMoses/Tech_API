using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingMouseService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGamingMousesAsync(Guid productId,
       GamingMouseLinkParameters linkParameters, bool trackChanges);
    Task<GamingMouseDTO> GetGamingMouseAsync(Guid productId, Guid id, bool trackChanges);
    Task<GamingMouseDTO> CreateGamingMouseForProductAsync(Guid productId,
        GamingMouseCreateDTO gamingMouseCreate, bool trackChanges);
    Task DeleteGamingMouseForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGamingMouseForProductAsync(Guid productId, Guid id,
        GamingMouseUpdateDTO gamingMouseUpdate, bool productTrackChanges, bool gamingMouseTrackChanges);
    Task<(GamingMouseUpdateDTO gamingMouseToPatch, GamingMouse gamingMouseEntity)> GetGamingMouseForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool gamingMouseTrackChanges);
    Task SaveChangesForPatchAsync(GamingMouseUpdateDTO gamingMouseToPatch, GamingMouse gamingMouseEntity);
}


