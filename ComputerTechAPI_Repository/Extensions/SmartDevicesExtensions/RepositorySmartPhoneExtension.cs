using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.SmartDevicesExtensions;

public static class RepositorySmartPhoneExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<SmartPhone> FilterSmartPhones(this IQueryable<SmartPhone> smartPhone, double minRating, double maxRating) =>
    //      smartPhones.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<SmartPhone> Search(this IQueryable<SmartPhone>
        smartPhones, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return smartPhones;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return smartPhones.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<SmartPhone> Sort(this IQueryable
    //    <SmartPhone> smartPhones, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return smartPhones.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<SmartPhone>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return smartPhones.OrderBy(p => p.Name);
    //    return smartPhones.OrderBy(orderQuery);
    //}
}
