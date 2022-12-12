using ComputerTechAPI_Entities.Tech_Models.Gaming;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.GamingExtensions;

public static class RepositoryGamingLaptopExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GamingLaptop> FilterGamingLaptops(this IQueryable<GamingLaptop> gamingLaptops, double minRating, double maxRating) =>
    //      gamingLaptops.Where(g => g.Rating >= minRating && g.Rating <= maxRating);

    public static IQueryable<GamingLaptop> Search(this IQueryable<GamingLaptop>
        gamingLaptops, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gamingLaptops;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gamingLaptops.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GamingLaptop> Sort(this IQueryable
    //    <GamingLaptop> gamingLaptops, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gamingLaptops.OrderBy(g => g.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GamingLaptop>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gamingLaptops.OrderBy(g => g.Name);
    //    return gamingLaptops.OrderBy(orderQuery);
    //}
}
