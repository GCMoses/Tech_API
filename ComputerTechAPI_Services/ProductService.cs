using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models;
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


    public ProductDTO CreateProduct(ProductCreateDTO productCreate)
    {
        var productEntity = _mapper.Map<Product>(productCreate);

        _repository.Product.CreateProduct(productEntity);
        _repository.Save();

        var productToReturn = _mapper.Map<ProductDTO>(productEntity);

        return productToReturn;
    }

    public IEnumerable<ProductDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var productEntities = _repository.Product.GetByIds(ids, trackChanges);
        if (ids.Count() != productEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var productToReturn = _mapper.Map<IEnumerable<ProductDTO>>(productEntities);

        return productToReturn;
    }

    public void DeleteProduct(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        _repository.Product.DeleteProduct(product);
        _repository.Save();
    }

    public void UpdateProduct(Guid productId, ProductUpdateDTO productUpdate, bool trackChanges)
    {
        var productEntity = _repository.Product.GetProduct(productId, trackChanges);
        if (productEntity is null)
            throw new ProductNotFoundException(productId);

        _mapper.Map(productUpdate, productEntity);
        _repository.Save();
    }


}

