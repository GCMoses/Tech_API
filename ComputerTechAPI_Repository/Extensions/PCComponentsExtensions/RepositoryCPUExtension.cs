using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryCPUExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<CPU> FilterCPUs(this IQueryable<CPU> cpu, double minRating, double maxRating) =>
    //      cpus.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<CPU> Search(this IQueryable<CPU>
        cpus, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return cpus;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return cpus.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<CPU> Sort(this IQueryable
    //    <CPU> cpus, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return cpus.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<CPU>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return cpus.OrderBy(p => p.Name);
    //    return cpus.OrderBy(orderQuery);
    //}
}
