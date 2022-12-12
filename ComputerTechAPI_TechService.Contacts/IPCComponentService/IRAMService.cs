using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IRAMService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetRAMsAsync(Guid productId,
     RAMLinkParameters linkParameters, bool trackChanges);
    Task<RAMDTO> GetRAMAsync(Guid productId, Guid id, bool trackChanges);
    Task<RAMDTO> CreateRAMForProductAsync(Guid productId,
       RAMCreateDTO ramCreate, bool trackChanges);
    Task DeleteRAMForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateRAMForProductAsync(Guid productId, Guid id,
        RAMUpdateDTO ramUpdate, bool productTrackChanges, bool ramTrackChanges);
    Task<(RAMUpdateDTO ramToPatch, RAM ramEntity)> GetRAMForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool ramTrackChanges);
    Task SaveChangesForPatchAsync(RAMUpdateDTO ramToPatch, RAM ramEntity);
}


