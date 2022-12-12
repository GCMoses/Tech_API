using ComputerTechAPI_Entities.Tech_Models.PC;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCExtensions;

public static class RepositoryDesktopExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<Desktop> FilterDesktops(this IQueryable<Router> desktops, double minRating, double maxRating) =>
    //      desktops.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<Desktop> Search(this IQueryable<Desktop>
        desktops, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return desktops;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return desktops.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<Desktop> Sort(this IQueryable
    //    <Desktop> desktops, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return desktops.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Desktop>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return desktops.OrderBy(p => p.Name);
    //    return desktops.OrderBy(orderQuery);
    //}
}
