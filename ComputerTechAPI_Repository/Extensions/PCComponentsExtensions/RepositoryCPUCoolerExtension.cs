using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryCPUCoolerExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<CPUCooler> FilterCPUCoolers(this IQueryable<CPUCooler> cpu, double minRating, double maxRating) =>
    //      cpuCoolers.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<CPUCooler> Search(this IQueryable<CPUCooler>
        cpuCoolers, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return cpuCoolers;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return cpuCoolers.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<CPUCooler> Sort(this IQueryable
    //    <CPUCooler> cpuCoolers, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return cpuCoolers.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<CPUCooler>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return cpuCoolers.OrderBy(p => p.Name);
    //    return cpuCoolers.OrderBy(orderQuery);
    //}
}
