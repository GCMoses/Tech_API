using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class HDDRepository : RepositoryBase<HDD>, IHDDRepository
{
    public HDDRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public IEnumerable<HDD> GetHDDs(Guid productId, bool trackChanges) =>
       FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
      .OrderBy(c => c.Name)
      .ToList();


    public HDD GetHDD(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateHDDForProduct(Guid productId, HDD hdd)
    {
        hdd.ProductId = productId;
        Create(hdd);
    }


    public void DeleteHDD(HDD hdd) => Delete(hdd);
}
