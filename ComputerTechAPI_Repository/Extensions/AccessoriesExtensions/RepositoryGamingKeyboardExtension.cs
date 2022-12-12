using ComputerTechAPI_Entities.Tech_Models.Accessories;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;

public static class RepositoryGamingKeyboardExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GamingKeyboard> FilterGamingKeyboards(this IQueryable<GamingKeyboard> gamingKeyboards, double minRating, double maxRating) =>
    //      gamingKeyboards.Where(g => g.Rating >= minRating && g.Rating <= maxRating);

    public static IQueryable<GamingKeyboard> Search(this IQueryable<GamingKeyboard>
        gamingKeyboards, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gamingKeyboards;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gamingKeyboards.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GamingKeyboard> Sort(this IQueryable
    //    <GamingKeyboard> gamingKeyboards, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gamingKeyboards.OrderBy(g => g.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GamingKeyboard>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gamingKeyboards.OrderBy(g => g.Name);
    //    return gamingKeyboards.OrderBy(orderQuery);
    //}
}
