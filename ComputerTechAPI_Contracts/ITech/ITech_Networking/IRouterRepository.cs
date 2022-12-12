using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.NetworkingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Networking;

namespace ComputerTechAPI_Contracts.ITech.ITech_Networking;

public interface IRouterRepository
{
    Task<PagedList<Router>> GetRoutersAsync(Guid productId, RouterParams routerParams, bool trackChanges);
    Task<Router> GetRouterAsync(Guid productId, Guid id, bool trackChanges);

    void CreateRouterForProduct(Guid productId, Router router);

    void DeleteRouter(Router router);
}
