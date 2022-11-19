using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;


public interface IGamingHeadphonesAndHeadsetRepository
{
    IEnumerable<GamingHeadphonesAndHeadset> GetGamingHeadphonesAndHeadsets(Guid productId, bool trackChanges);

    GamingHeadphonesAndHeadset GetGamingHeadphonesAndHeadset(Guid productId, Guid id, bool trackChanges);

    void CreateGamingHeadphonesAndHeadset(GamingHeadphonesAndHeadset gamingHeadphonesAndHeadset);
}
