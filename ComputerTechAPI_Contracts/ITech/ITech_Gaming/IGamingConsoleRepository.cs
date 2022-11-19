using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Contracts.ITech.ITech_Gaming;

public interface IGamingConsoleRepository
{
    IEnumerable<GamingConsole> GetGamingConsoles(Guid productId, bool trackChanges);

    GamingConsole GetGamingConsole(Guid productId, Guid id, bool trackChanges);

    void CreateGamingConsole(GamingConsole gamingConsole);
}
