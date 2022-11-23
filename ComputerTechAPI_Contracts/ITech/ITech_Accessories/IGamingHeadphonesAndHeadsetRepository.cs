using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;


public interface IGamingHeadphonesAndHeadsetRepository
{
    IEnumerable<GamingHeadphonesAndHeadset> GetGamingHeadphonesAndHeadsets(Guid productId, bool trackChanges);

    GamingHeadphonesAndHeadset GetGamingHeadphonesAndHeadset(Guid productId, Guid id, bool trackChanges);

    void CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset);

    void DeleteGamingHeadphonesAndHeadset(GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset); 
}
