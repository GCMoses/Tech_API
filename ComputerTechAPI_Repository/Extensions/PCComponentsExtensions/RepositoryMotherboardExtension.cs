using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCComponentExtensions;

public static class RepositoryMotherboardExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<Motherboards> FilterMotherboards(this IQueryable<Motherboard> motherboard, double minRating, double maxRating) =>
    //      motherboards.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<Motherboard> Search(this IQueryable<Motherboard>
        motherboards, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return motherboards;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return motherboards.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<Motherboard> Sort(this IQueryable
    //    <Motherboard> motherboards, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return motherboards.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Motherboard>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return motherboards.OrderBy(p => p.Name);
    //    return motherboards.OrderBy(orderQuery);
    //}
}
