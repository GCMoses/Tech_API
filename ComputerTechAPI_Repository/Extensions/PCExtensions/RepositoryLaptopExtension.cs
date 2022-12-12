using ComputerTechAPI_Entities.Tech_Models.PC;
using System.Linq.Dynamic.Core;

namespace ComputerTechAPI_Repository.Extensions.PCExtensions;

public static class RepositoryLaptopExtensions
{
    //if filtering ever become a need we can implement these lines and call the method from the params

    //public static IQueryable<Laptop> FilterLaptops(this IQueryable<Laptop> laptops, double minRating, double maxRating) =>
    //      laptops.Where(p => p.Rating >= minRating && p.Rating <= maxRating);

    public static IQueryable<Laptop> Search(this IQueryable<Laptop>
        laptops, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return laptops;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return laptops.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }

    //public static IQueryable<Laptop> Sort(this IQueryable
    //    <Laptop> laptops, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return laptops.OrderBy(p => p.Name);
    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Laptop>(orderByQueryString);
    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return laptops.OrderBy(p => p.Name);
    //    return laptops.OrderBy(orderQuery);
    //}
}
