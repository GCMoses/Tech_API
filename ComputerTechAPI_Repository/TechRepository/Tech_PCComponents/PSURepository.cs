using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class PSURepository : RepositoryBase<PSU>, IPSURepository
{
    public PSURepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public IEnumerable<PSU> GetPSUs(Guid productId, bool trackChanges) =>
       FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
      .OrderBy(c => c.Name)
      .ToList();


    public PSU GetPSU(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreatePSUForProduct(Guid productId, PSU psu)
    {
        psu.ProductId = productId;
        Create(psu);
    }


    public void DeletePSU(PSU psu) => Delete(psu);
}
