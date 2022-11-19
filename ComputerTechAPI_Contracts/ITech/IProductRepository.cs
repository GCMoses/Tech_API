using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Contracts.ITech;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    Product GetProduct(Guid productId, bool trackChanges);

}
