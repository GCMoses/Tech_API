using ComputerTechAPI_Contracts.ITech.ITech_Networking;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.NetworkingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;
using ComputerTechAPI_Repository.Extensions.NewtorkingExtensions;
using ComputerTechAPI_Repository.Extensions.PCExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Networking;

public class RouterRepository : RepositoryBase<Router>, IRouterRepository
{
    public RouterRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<Router>> GetRoutersAsync(Guid productId,
           RouterParams routerParams, bool trackChanges)
    {
        var router = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
      //.FilterRouters(routerParams.MinRating, routerParams.MaxRating)
        .Search(routerParams.SearchTerm)
      //.Sort(routerParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<Router>(router, count,
        routerParams.PageNumber, routerParams.PageSize);
    }
    public async Task<Router> GetRouterAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(r => r.ProductId.Equals(productId) && r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();



    public void CreateRouterForProduct(Guid productId, Router router)
    {
        router.ProductId = productId;
        Create(router);
    }


    public void DeleteRouter(Router router) => Delete(router);
}
