using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryCaseExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<Case> FilterCases(this IQueryable<Case> pcCases, double minRating, double maxRating) =>
    //      pcCases.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<Case> Search(this IQueryable<Case>
        pcCases, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return pcCases;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return pcCases.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<Case> Sort(this IQueryable
    //    <Case> pcCases, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return pcCases.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Case>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return pcCases.OrderBy(p => p.Name);
    //    return pcCases.OrderBy(orderQuery);
    //    return pcCases.OrderBy(orderQuery);
    //}
}
