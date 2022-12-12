using ComputerTechAPI_Entities.Tech_Models.Gaming;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.GamingExtensions;

public static class RepositoryGamingDesktopExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GamingDesktop> FilterGamingDesktops(this IQueryable<GamingDesktop> gamingDesktops, double minRating, double maxRating) =>
    //      gamingDesktops.Where(g => g.Rating >= minRating && g.Rating <= maxRating);

    public static IQueryable<GamingDesktop> Search(this IQueryable<GamingDesktop>
        gamingDesktops, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gamingDesktops;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gamingDesktops.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GamingDesktop> Sort(this IQueryable
    //    <GamingDesktop> gamingDesktops, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gamingDesktops.OrderBy(g => g.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GamingDesktop>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gamingDesktops.OrderBy(g => g.Name);
    //    return gamingDesktops.OrderBy(orderQuery);
    //}
}
