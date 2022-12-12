using ComputerTechAPI_Entities.Tech_Models.Gaming;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.GamingExtensions;

public static class RepositoryGamingConsoleExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GamingConsole> FilterGamingConsoles(this IQueryable<GamingConsole> gamingConsoles, double minRating, double maxRating) =>
    //      gamingConsoles.Where(g => g.Rating >= minRating && g.Rating <= maxRating);

    public static IQueryable<GamingConsole> Search(this IQueryable<GamingConsole>
        gamingConsoles, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gamingConsoles;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gamingConsoles.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GamingConsole> Sort(this IQueryable
    //    <GamingConsole> gamingConsoles, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gamingConsoles.OrderBy(g => g.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GamingConsole>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gamingMouses.OrderBy(g => g.Name);
    //    return gamingConsoles.OrderBy(orderQuery);
    //}
}
