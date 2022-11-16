using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_TechService.Contracts;
namespace ComputerTechAPI_Services;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public ProductService(IRepositoryManager repository, ILogsManager
    logger)

    {
        _repository = repository;
        _logger = logger;
    }
 

 

    public IEnumerable<ProductDTO> GetAllProducts(bool trackChanges)
    {
        try
        {
            var products = _repository.Product.GetAllProducts(trackChanges);
            var productDto = products.Select(p => new ProductDTO(p.Id, p.Category)).ToList();
            return productDto;

        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllProducts)}service method {ex}");
            throw;
        }
    }
}

