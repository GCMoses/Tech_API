using ComputerTechAPI_Contracts.ITech;
using ComputerTechAPI_Entities.Tech_Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ComputerTechAPI_Repository.TechRepository;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges).OrderBy(p => p.Category).ToList();

    public Product GetProduct(Guid productId, bool trackChanges) => FindByCondition(p => p.Id.Equals(productId), trackChanges)
    .SingleOrDefault();


    public void CreateProduct(Product product) => Create(product);


    public IEnumerable<Product> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
 FindByCondition(p => ids.Contains(p.Id), trackChanges)
    .ToList();



    public void DeleteProduct(Product product) => Delete(product);
}
