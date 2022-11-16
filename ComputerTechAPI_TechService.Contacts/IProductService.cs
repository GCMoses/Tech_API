using ComputerTechAPI_DtoAndFeatures.DTO;

namespace ComputerTechAPI_TechService.Contracts;

public interface IProductService
{
    IEnumerable<ProductDTO> GetAllProducts(bool trackChanges);
}

