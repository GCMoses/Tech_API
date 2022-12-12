using ComputerTechAPI_Entities.Tech_Models.Accessories;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.AccessoriesExtensions;

public static class RepositoryGamingHeadphonesAndHeadsetExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<GamingHeadphonesAndHeadset> FilterGamingHeadphonesAndHeadsets(this IQueryable<GamingHeadphonesAndHeadset> gamingHeadphonesAndHeadsets, double minRating, double maxRating) =>
    //      gamingHeadphonesAndHeadsets.Where(g => g.Rating >= minRating && g.Rating <= maxRating);

    public static IQueryable<GamingHeadphonesAndHeadset> Search(this IQueryable<GamingHeadphonesAndHeadset>
        gamingHeadphonesAndHeadsets, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return gamingHeadphonesAndHeadsets;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return gamingHeadphonesAndHeadsets.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<GamingHeadphonesAndHeadset> Sort(this IQueryable
    //    <GamingHeadphonesAndHeadset> gamingHeadphonesAndHeadsets, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return gamingHeadphonesAndHeadsets.OrderBy(g => g.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<GamingHeadphonesAndHeadset>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return gamingHeadphonesAndHeadsets.OrderBy(g => g.Name);
    //    return gamingHeadphonesAndHeadsets.OrderBy(orderQuery);
    //}
}
