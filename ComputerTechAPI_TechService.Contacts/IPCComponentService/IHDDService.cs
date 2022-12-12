using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IHDDService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetHDDsAsync(Guid productId,
        HDDLinkParameters linkParameters, bool trackChanges);
    Task<HDDDTO> GetHDDAsync(Guid productId, Guid id, bool trackChanges);
    Task<HDDDTO> CreateHDDForProductAsync(Guid productId,
       HDDCreateDTO hddCreate, bool trackChanges);
    Task DeleteHDDForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateHDDForProductAsync(Guid productId, Guid id,
        HDDUpdateDTO hddUpdate, bool productTrackChanges, bool hddTrackChanges);
    Task<(HDDUpdateDTO hddToPatch, HDD hddEntity)> GetHDDForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool hddTrackChanges);
    Task SaveChangesForPatchAsync(HDDUpdateDTO hddToPatch, HDD hddEntity);
}
