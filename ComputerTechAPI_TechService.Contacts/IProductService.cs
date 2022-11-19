using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_TechService.Contracts;

public interface IProductService
{
    IEnumerable<ProductDTO> GetAllProducts(bool trackChanges);
    ProductDTO GetProduct(Guid productId, bool trackChanges);
}

