using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PC;

public class LaptopRepository : RepositoryBase<Laptop>, ILaptopRepository
{
    public LaptopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<Laptop> GetLaptops(Guid productId, bool trackChanges) =>
        FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
       .OrderBy(p => p.Name)
       .ToList();


    public Laptop GetLaptop(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}