using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Contracts.ITech.ITech_PC;

public interface IDesktopRepository
{
    IEnumerable<Desktop> GetDesktops(Guid productId, bool trackChanges);

    Desktop GetDesktop(Guid productId, Guid id, bool trackChanges);

    void CreateDesktop(Desktop desktop);
}
