using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.SmartDevicesExtensions;

public static class RepositoryDroneExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<Drone> FilterDrones(this IQueryable<Drone> drone, double minRating, double maxRating) =>
    //      drones.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<Drone> Search(this IQueryable<Drone>
        drones, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return drones;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return drones.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<Drone> Sort(this IQueryable
    //    <Drone> drones, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return drones.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Drone>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return drones.OrderBy(p => p.Name);
    //    return drones.OrderBy(orderQuery);
    //}
}
