using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class CaseRepository : RepositoryBase<Case>, ICaseRepository
{
    public CaseRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<Case>> GetCasesAsync(Guid productId,
             CaseParams pcCaseParams, bool trackChanges)
    {
        var pcCase = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterCases(pcCaseParams.MinRating, pcCaseParams.MaxRating)
        .Search(pcCaseParams.SearchTerm)
        //.Sort(pcCaseParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<Case>(pcCase, count,
        pcCaseParams.PageNumber, pcCaseParams.PageSize);
    }
    public async Task<Case> GetCaseAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateCaseForProduct(Guid productId, Case pcCase)
    {
        pcCase.ProductId = productId;
        Create(pcCase);
    }


    public void DeleteCase(Case pcCase) => Delete(pcCase);
}