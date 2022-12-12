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
    public ProductService(IRepositoryManager repository, ILogsManager logger, IMapper mapper)

    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges)
    {
      
            var products = await _repository.Product.GetAllProductsAsync(trackChanges);
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productDTO;
    }

    public async Task<ProductDTO> GetProductAsync(Guid id, bool trackChanges)
    {   
        var product = await _repository.Product.GetProductAsync(id, trackChanges);
        //Check if the product is null 
        if (product is null)
            throw new ProductNotFoundException(id); 
        var productDTO = _mapper.Map<ProductDTO>(product);  
        return productDTO;
    }


    public async Task<ProductDTO> CreateProductAsync(ProductCreateDTO productCreate)
    {
        var productEntity = _mapper.Map<Product>(productCreate);

        _repository.Product.CreateProduct(productEntity);
        await _repository.SaveAsync();

        var productToReturn = _mapper.Map<ProductDTO>(productEntity);

        return productToReturn;
    }


    public async Task<IEnumerable<ProductDTO>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var productEntities = await _repository.Product.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != productEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var productsToReturn = _mapper.Map<IEnumerable<ProductDTO>>(productEntities);

        return productsToReturn;
    }


    public async Task<(IEnumerable<ProductDTO> products, string ids)> CreateProductCollectionAsync
        (IEnumerable<ProductCreateDTO> productCollection)
    {
        if (productCollection is null)
            throw new ProductCollectionBadRequest();

        var productEntities = _mapper.Map<IEnumerable<Product>>(productCollection);
        foreach (var product in productEntities)
        {
            _repository.Product.CreateProduct(product);
        }

        await _repository.SaveAsync();

        var productCollectionToReturn = _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
        var ids = string.Join(",", productCollectionToReturn.Select(p => p.Id));
        //I can chain all id's together in request
        return (products: productCollectionToReturn, ids: ids);
    }

    public async Task DeleteProductAsync(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        _repository.Product.DeleteProduct(product);
        await _repository.SaveAsync();
    }

    public async Task UpdateProductAsync(Guid productId, ProductUpdateDTO productUpdate, bool trackChanges)
    {
        var productEntity = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (productEntity is null)
            throw new ProductNotFoundException(productId);

        _mapper.Map(productUpdate, productEntity);
        await _repository.SaveAsync();
    }

   
}

