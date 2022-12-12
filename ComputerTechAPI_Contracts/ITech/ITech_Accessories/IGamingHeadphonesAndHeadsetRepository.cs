using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;


public interface IGamingHeadphonesAndHeadsetRepository
{
    Task<PagedList<GamingHeadphonesAndHeadset>> GetGamingHeadphonesAndHeadsetsAsync(Guid productId,
        GamingHeadphonesAndHeadsetParams gamingHeadphonesAndHeadsetParams, bool trackChanges);


    Task<GamingHeadphonesAndHeadset> GetGamingHeadphonesAndHeadsetAsync(Guid productId, Guid id, bool trackChanges);

    void CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset);

    void DeleteGamingHeadphonesAndHeadset(GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset); 
}
