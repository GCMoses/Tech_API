using ComputerTechAPI_Entities.Tech_Models.Networking;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.NewtorkingExtensions;

public static class RepositoryRouterExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<Router> FilterRouters(this IQueryable<Router> routers, double minRating, double maxRating) =>
    //      routers.Where(r => r.Rating >= minRating && r.Rating <= maxRating);

    public static IQueryable<Router> Search(this IQueryable<Router>
        routers, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return routers;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return routers.Where(r => r.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<Router> Sort(this IQueryable
    //    <Router> routers, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return routers.OrderBy(r => r.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Router>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return routers.OrderBy(r => r.Name);
    //    return routers.OrderBy(orderQuery);
    //}
}
