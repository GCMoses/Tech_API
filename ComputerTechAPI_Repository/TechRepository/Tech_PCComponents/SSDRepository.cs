using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class SSDRepository : RepositoryBase<SSD>, ISSDRepository
{
    public SSDRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<SSD> GetSSDs(Guid productId, bool trackChanges) =>
       FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
      .OrderBy(g => g.Name)
      .ToList();


    public SSD GetSSD(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}