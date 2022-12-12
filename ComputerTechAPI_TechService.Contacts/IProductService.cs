using ComputerTechAPI_DtoAndFeatures.DTO;

namespace ComputerTechAPI_TechService.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges);

    Task<ProductDTO> GetProductAsync(Guid productId, bool trackChanges);

    Task<ProductDTO> CreateProductAsync(ProductCreateDTO productCreate);

    Task<IEnumerable<ProductDTO>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

    Task<(IEnumerable<ProductDTO> products, string ids)> CreateProductCollectionAsync
         (IEnumerable<ProductCreateDTO> productCollection);

    Task DeleteProductAsync(Guid productId, bool trackChanges);

    Task UpdateProductAsync(Guid productId, ProductUpdateDTO productUpdate, bool trackChanges);
}
