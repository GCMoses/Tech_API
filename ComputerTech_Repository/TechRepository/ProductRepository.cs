using ComputerTechAPI_Contracts.ITech;
using ComputerTechAPI_Entities.Tech_Models;
namespace ComputerTech_Repository.TechRepository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
