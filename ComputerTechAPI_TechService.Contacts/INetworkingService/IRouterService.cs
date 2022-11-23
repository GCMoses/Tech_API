using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTechAPI_TechService.Contracts.INetworkingService;

public interface IRouterService
{
    IEnumerable<RouterDTO> GetRouters(Guid productId, bool trackChanges);

    RouterDTO GetRouter(Guid productId, Guid id, bool trackChanges);

    RouterDTO CreateRouterForProduct(Guid productId, RouterCreateDTO routerCreate, bool trackChanges);

    void DeleteRouterForProduct(Guid productId, Guid id, bool trackChanges);
    void UpdateRouterForProduct(Guid productId, Guid id, RouterUpdateDTO routerUpdate,
                                                         bool productTrackChanges, bool routerTrackChanges);
}


