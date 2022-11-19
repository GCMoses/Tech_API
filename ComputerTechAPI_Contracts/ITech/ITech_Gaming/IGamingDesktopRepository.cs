using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Contracts.ITech.ITech_Gaming;

public interface IGamingDesktopRepository
{
    IEnumerable<GamingDesktop> GetGamingDesktops(Guid productId, bool trackChanges);

    GamingDesktop GetGamingDesktop(Guid productId, Guid id, bool trackChanges);

    void CreateGamingDesktop(GamingDesktop gamingDesktop);
}
