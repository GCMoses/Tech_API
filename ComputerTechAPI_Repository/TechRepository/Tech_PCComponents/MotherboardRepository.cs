using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class MotherboardRepository : RepositoryBase<Motherboard>, IMotherboardRepository
{
    public MotherboardRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public IEnumerable<Motherboard> GetMotherboards(Guid productId, bool trackChanges) =>
       FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
      .OrderBy(c => c.Name)
      .ToList();


    public Motherboard GetMotherboard(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateMotherboardForProduct(Guid productId, Motherboard motherboard)
    {
        motherboard.ProductId = productId;
        Create(motherboard);
    }

    public void DeleteMotherboard(Motherboard motherboard) => Delete(motherboard);
}