using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICaseRepository
{
    Task<PagedList<Case>> GetCasesAsync(Guid productId, CaseParams pcCaseParams, bool trackChanges);

    Task<Case> GetCaseAsync(Guid productId, Guid id, bool trackChanges);

    void CreateCaseForProduct(Guid productId, Case pcCase);

    void DeleteCase(Case pcCase);
}
