using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingHeadphonesAndHeadsetService
{
    IEnumerable<GamingHeadphonesAndHeadsetDTO> GetGamingHeadphonesAndHeadsets(Guid productId, bool trackChanges);
    GamingHeadphonesAndHeadsetDTO GetGamingHeadphonesAndHeadset(Guid productId, Guid id, bool trackChanges);

    GamingHeadphonesAndHeadsetDTO CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadsetCreate, bool trackChanges);


    void DeleteGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id, GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetUpdate, 
                                                    bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges);

    (GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetToPatch, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadsetEntity) GetGamingHeadphonesAndHeadsetForPatch(
Guid productId, Guid id, bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges);
    void SaveChangesForPatch(GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetToPatch, GamingHeadphonesAndHeadset
    gamingHeadphonesAndHeadsetEntity);

}
