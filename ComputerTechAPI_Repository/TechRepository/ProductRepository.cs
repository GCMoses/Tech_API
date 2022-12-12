using ComputerTechAPI_Contracts.ITech;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.EntityFrameworkCore;
    
namespace ComputerTechAPI_Repository.TechRepository;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }


    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) => await FindAll(trackChanges)
    .OrderBy(p => p.Category)
    .ToListAsync();


    public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) => await FindByCondition
        (p => p.Id.Equals(productId), trackChanges)
        .SingleOrDefaultAsync();


    public void CreateProduct(Product product) => Create(product);


    public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(p => ids.Contains(p.Id), trackChanges)
        .ToListAsync();



    public void DeleteProduct(Product product) => Delete(product);
}
