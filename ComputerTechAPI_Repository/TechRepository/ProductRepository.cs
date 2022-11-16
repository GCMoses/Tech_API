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
}
