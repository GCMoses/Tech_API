using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class CPUCoolerRepository : RepositoryBase<CPUCooler>, ICPUCoolerRepository
{
    public CPUCoolerRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<CPUCooler> GetCPUCoolers(Guid productId, bool trackChanges) =>
       FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
      .OrderBy(c => c.Name)
      .ToList();


    public CPUCooler GetCPUCooler(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateCPUCooler(CPUCooler cpuCooler) => Create(cpuCooler);
    public void CreateCPUCoolerForProduct(Guid productId, CPUCooler cpuCooler)
    {
        cpuCooler.ProductId = productId;
        Create(cpuCooler);
    }


    public void DeleteCPUCooler(CPUCooler cpuCooler) => Delete(cpuCooler);
}
