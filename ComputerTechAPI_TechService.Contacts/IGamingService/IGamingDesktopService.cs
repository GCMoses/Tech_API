using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingDesktopService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGamingDesktopsAsync(Guid productId,
       GamingDesktopLinkParameters linkParameters, bool trackChanges);
    Task<GamingDesktopDTO> GetGamingDesktopAsync(Guid productId, Guid id, bool trackChanges);
    Task<GamingDesktopDTO> CreateGamingDesktopForProductAsync(Guid productId,
        GamingDesktopCreateDTO gamingDesktopCreate, bool trackChanges);
    Task DeleteGamingDesktopForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGamingDesktopForProductAsync(Guid productId, Guid id,
        GamingDesktopUpdateDTO gamingDesktopUpdate, bool productTrackChanges, bool gamingDesktopTrackChanges);
    Task<(GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop gamingDesktopEntity)> GetGamingDesktopForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool gamingDesktopTrackChanges);
    Task SaveChangesForPatchAsync(GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop gamingDesktopEntity);
}
