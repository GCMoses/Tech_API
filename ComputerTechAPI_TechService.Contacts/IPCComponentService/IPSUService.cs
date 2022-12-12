using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IPSUService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetPSUsAsync(Guid productId,
        PSULinkParameters linkParameters, bool trackChanges);
    Task<PSUDTO> GetPSUAsync(Guid productId, Guid id, bool trackChanges);
    Task<PSUDTO> CreatePSUForProductAsync(Guid productId,
       PSUCreateDTO psuCreate, bool trackChanges);
    Task DeletePSUForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdatePSUForProductAsync(Guid productId, Guid id,
        PSUUpdateDTO psuUpdate, bool productTrackChanges, bool psuTrackChanges);
    Task<(PSUUpdateDTO psuToPatch, PSU psuEntity)> GetPSUForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool psuTrackChanges);
    Task SaveChangesForPatchAsync(PSUUpdateDTO psuToPatch, PSU psuEntity);
}