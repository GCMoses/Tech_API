using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.NetworkingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Networking;


namespace ComputerTechAPI_TechService.Contracts.INetworkingService;

public interface IRouterService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetRoutersAsync(Guid productId,
        RouterLinkParameters linkParameters, bool trackChanges);
    Task<RouterDTO> GetRouterAsync(Guid productId, Guid id, bool trackChanges);
    Task<RouterDTO> CreateRouterForProductAsync(Guid productId,
         RouterCreateDTO routerCreate, bool trackChanges);
    Task DeleteRouterForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateRouterForProductAsync(Guid productId, Guid id, RouterUpdateDTO routerUpdate,
         bool productTrackChanges, bool routerTrackChanges);
    Task<(RouterUpdateDTO routerToPatch, Router routerEntity)> GetRouterForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool routerTrackChanges);
    Task SaveChangesForPatchAsync(RouterUpdateDTO routerToPatch, Router routerEntity);
}


