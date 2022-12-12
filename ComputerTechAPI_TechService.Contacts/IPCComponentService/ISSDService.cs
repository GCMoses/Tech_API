using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ISSDService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetSSDsAsync(Guid productId,
     SSDLinkParameters linkParameters, bool trackChanges);
    Task<SSDDTO> GetSSDAsync(Guid productId, Guid id, bool trackChanges);
    Task<SSDDTO> CreateSSDForProductAsync(Guid productId,
       SSDCreateDTO ssdCreate, bool trackChanges);
    Task DeleteSSDForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateSSDForProductAsync(Guid productId, Guid id,
        SSDUpdateDTO ssdUpdate, bool productTrackChanges, bool ssdTrackChanges);
    Task<(SSDUpdateDTO ssdToPatch, SSD ssdEntity)> GetSSDForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool ssdTrackChanges);
    Task SaveChangesForPatchAsync(SSDUpdateDTO ssdToPatch, SSD ssdEntity);
}
