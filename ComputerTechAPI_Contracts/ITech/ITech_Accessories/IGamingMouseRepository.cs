using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;

public interface IGamingMouseRepository
{
    IEnumerable<GamingMouse> GetGamingMouses(Guid productId, bool trackChanges);

    GamingMouse GetGamingMouse(Guid productId, Guid id, bool trackChanges);

    void CreateGamingMouse(GamingMouse gamingMouse);
}
