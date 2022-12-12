using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICaseService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetCasesAsync(Guid productId,
        CaseLinkParameters linkParameters, bool trackChanges);
    Task<CaseDTO> GetCaseAsync(Guid productId, Guid id, bool trackChanges);
    Task<CaseDTO> CreateCaseForProductAsync(Guid productId,
       CaseCreateDTO pcCaseCreate, bool trackChanges);
    Task DeleteCaseForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateCaseForProductAsync(Guid productId, Guid id,
        CaseUpdateDTO pcCaseUpdate, bool productTrackChanges, bool pcCaseTrackChanges);
    Task<(CaseUpdateDTO pcCaseToPatch, Case pcCaseEntity)> GetCaseForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool pcCaseTrackChanges);
    Task SaveChangesForPatchAsync(CaseUpdateDTO pcCaseToPatch, Case pcCaseEntity);
}
