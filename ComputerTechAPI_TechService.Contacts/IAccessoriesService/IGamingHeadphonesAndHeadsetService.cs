using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingHeadphonesAndHeadsetService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGamingHeadphonesAndHeadsetsAsync(Guid productId,
        GamingHeadphonesAndHeadsetLinkParameters linkParameters, bool trackChanges);
    Task<GamingHeadphonesAndHeadsetDTO> GetGamingHeadphonesAndHeadsetAsync(Guid productId, Guid id, bool trackChanges);
    Task<GamingHeadphonesAndHeadsetDTO> CreateGamingHeadphonesAndHeadsetForProductAsync(Guid productId,
        GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadsetCreate, bool trackChanges);
    Task DeleteGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id,
        GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetUpdate, bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges);
    Task<(GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetToPatch, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadsetEntity)> GetGamingHeadphonesAndHeadsetForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges);
    Task SaveChangesForPatchAsync(GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetToPatch, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadsetEntity);
}
