using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryRAMExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<RAM> FilterRAMs(this IQueryable<RAM> ram, double minRating, double maxRating) =>
    //      rams.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<RAM> Search(this IQueryable<RAM>
        rams, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return rams;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return rams.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<RAM> Sort(this IQueryable
    //    <RAM> rams, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return rams.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<RAM>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return rams.OrderBy(p => p.Name);
    //    return rams.OrderBy(orderQuery);
    //}
}
