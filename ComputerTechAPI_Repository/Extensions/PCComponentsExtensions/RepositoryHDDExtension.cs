using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryHDDExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<HDD> FilterHDDs(this IQueryable<HDD> hdd, double minRating, double maxRating) =>
    //      hdds.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<HDD> Search(this IQueryable<HDD>
        hdds, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return hdds;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return hdds.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<HDD> Sort(this IQueryable
    //    <HDD> hdds, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return hdds.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<HDD>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return hdds.OrderBy(p => p.Name);
    //    return hdds.OrderBy(orderQuery);
    //}
}
