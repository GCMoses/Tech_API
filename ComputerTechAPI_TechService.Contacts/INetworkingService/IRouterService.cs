using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTechAPI_TechService.Contracts.INetworkingService;

public interface IRouterService
{
    IEnumerable<RouterDTO> GetRouters(Guid productId, bool trackChanges);

    RouterDTO GetRouter(Guid productId, Guid id, bool trackChanges);
}
