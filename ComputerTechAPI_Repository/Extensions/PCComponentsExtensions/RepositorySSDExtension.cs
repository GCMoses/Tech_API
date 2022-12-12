using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositorySSDExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<SSD> SSDs(this IQueryable<SSD> ssd, double minRating, double maxRating) =>
    //      ssds.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<SSD> Search(this IQueryable<SSD>
        ssds, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return ssds;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return ssds.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<SSD> Sort(this IQueryable
    //    <SSD> ssds, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return ssds.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<SSD>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return ssds.OrderBy(p => p.Name);
    //    return ssds.OrderBy(orderQuery);
    //}
}
