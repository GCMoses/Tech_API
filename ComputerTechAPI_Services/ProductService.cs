using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts;
namespace ComputerTechAPI_Services;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public ProductService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)

    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public IEnumerable<ProductDTO> GetAllProducts(bool trackChanges)
    {
      
            var products = _repository.Product.GetAllProducts(trackChanges);
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productDTO;
    }

    public ProductDTO GetProduct(Guid id, bool trackChanges)
    {   
        var product = _repository.Product.GetProduct(id, trackChanges);
        //Check if the product is null 
        if (product is null)
            throw new ProductNotFoundException(id); 
        var productDTO = _mapper.Map<ProductDTO>(product);  
        return productDTO;
    }
}

