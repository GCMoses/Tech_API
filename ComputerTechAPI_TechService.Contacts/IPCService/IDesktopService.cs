using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_TechService.Contracts.PCService;

public interface IDesktopService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetDesktopsAsync(Guid productId,
         DesktopLinkParameters linkParameters, bool trackChanges);
    Task<DesktopDTO> GetDesktopAsync(Guid productId, Guid id, bool trackChanges);
    Task<DesktopDTO> CreateDesktopForProductAsync(Guid productId,
       DesktopCreateDTO desktopCreate, bool trackChanges);
    Task DeleteDesktopForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateDesktopForProductAsync(Guid productId, Guid id,
        DesktopUpdateDTO desktopUpdate, bool productTrackChanges, bool desktopTrackChanges);
    Task<(DesktopUpdateDTO desktopToPatch, Desktop desktopEntity)> GetDesktopForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool desktopTrackChanges);
    Task SaveChangesForPatchAsync(DesktopUpdateDTO desktopToPatch, Desktop desktopEntity);
}
