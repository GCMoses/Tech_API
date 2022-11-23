using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_TechService.Contracts;

public interface IProductService
{
    IEnumerable<ProductDTO> GetAllProducts(bool trackChanges);
    ProductDTO GetProduct(Guid productId, bool trackChanges);
    ProductDTO CreateProduct(ProductCreateDTO productCreate);
    IEnumerable<ProductDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

    void DeleteProduct(Guid productId, bool trackChanges);

    void UpdateProduct(Guid productId, ProductUpdateDTO productUpdate, bool trackChanges);
}
