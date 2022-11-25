using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICaseService
{
    IEnumerable<CaseDTO> GetCases(Guid productId, bool trackChanges);

    CaseDTO GetCase(Guid productId, Guid id, bool trackChanges);

    CaseDTO CreateCaseForProduct(Guid productId, CaseCreateDTO pcCaseCreate, bool trackChanges);

    void DeleteCaseForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateCaseForProduct(Guid productId, Guid id, CaseUpdateDTO pcCaseUpdate,
                                                         bool productTrackChanges, bool pcCaseTrackChanges);


    (CaseUpdateDTO pcCaseToPatch, Case pcCaseEntity) GetCaseForPatch(
Guid productId, Guid id, bool productTrackChanges, bool pcCaseTrackChanges);
    void SaveChangesForPatch(CaseUpdateDTO pcCaseToPatch, Case
    pcCaseEntity);
}
