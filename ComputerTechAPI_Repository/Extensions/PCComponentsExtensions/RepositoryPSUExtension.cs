using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryPSUExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<PSU> FilterPSUs(this IQueryable<PSU> psu, double minRating, double maxRating) =>
    //      psus.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<PSU> Search(this IQueryable<PSU>
        psus, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return psus;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return psus.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<PSU> Sort(this IQueryable
    //    <PSU> psus, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return psus.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<PSU>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return psus.OrderBy(p => p.Name);
    //    return psus.OrderBy(orderQuery);
    //}
}
