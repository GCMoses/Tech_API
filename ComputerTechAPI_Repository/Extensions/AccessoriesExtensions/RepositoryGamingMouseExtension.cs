using ComputerTechAPI_Entities.Tech_Models.Accessories;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;

public static class RepositoryGamingMouseExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GamingMouse> FilterGamingMouses(this IQueryable<GamingMouse> gamingMouses, double minRating, double maxRating) =>
    //      gamingMouses.Where(g => g.Rating >= minRating && g.Rating <= maxRating);

    public static IQueryable<GamingMouse> Search(this IQueryable<GamingMouse>
        gamingMouses, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gamingMouses;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gamingMouses.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GamingMouse> Sort(this IQueryable
    //    <GamingMouse> gamingMouses, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gamingMouses.OrderBy(g => g.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GamingMouse>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gamingMouses.OrderBy(g => g.Name);
    //    return gamingMouses.OrderBy(orderQuery);
    //}
}
