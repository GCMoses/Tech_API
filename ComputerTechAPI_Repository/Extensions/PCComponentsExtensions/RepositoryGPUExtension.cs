using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryGPUExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GPU> FilterGPUs(this IQueryable<GPU> gpu, double minRating, double maxRating) =>
    //      gpus.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<GPU> Search(this IQueryable<GPU>
        gpus, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gpus;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gpus.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GPU> Sort(this IQueryable
    //    <GPU> gpus, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gpus.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GPU>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gpus.OrderBy(p => p.Name);
    //    return gpus.OrderBy(orderQuery);
    //}
}
