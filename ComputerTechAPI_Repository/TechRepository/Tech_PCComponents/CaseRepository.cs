using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class CaseRepository : RepositoryBase<Case>, ICaseRepository
{
    public CaseRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<Case> GetCases(Guid productId, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
       .OrderBy(c => c.Name)
       .ToList();


    public Case GetCase(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.ProductId.Equals(productId) && c.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateCaseForProduct(Guid productId, Case pcCase)
    {
        pcCase.ProductId = productId;
        Create(pcCase);
    }


    public void DeleteCase(Case pcCase) => Delete(pcCase);
}