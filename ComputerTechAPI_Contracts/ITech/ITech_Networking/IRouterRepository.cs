using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTechAPI_Contracts.ITech.ITech_Networking;

public interface IRouterRepository
{
    IEnumerable<Router> GetRouters(Guid productId, bool trackChanges);

    Router GetRouter(Guid productId, Guid id, bool trackChanges);

    void CreateRouter(Router router);
}
