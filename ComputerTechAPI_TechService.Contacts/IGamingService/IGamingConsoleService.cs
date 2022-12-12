using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingConsoleService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGamingConsolesAsync(Guid productId,
          GamingConsoleLinkParameters linkParameters, bool trackChanges);
    
    Task<GamingConsoleDTO> GetGamingConsoleAsync(Guid productId, Guid id, bool trackChanges);
    Task<GamingConsoleDTO> CreateGamingConsoleForProductAsync(Guid productId,
         GamingConsoleCreateDTO gamingConsoleCreate, bool trackChanges);
    Task DeleteGamingConsoleForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGamingConsoleForProductAsync(Guid productId, Guid id,
         GamingConsoleUpdateDTO gamingConsoleUpdate, bool productTrackChanges, bool gamingConsoleTrackChanges);
    Task<(GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole gamingConsoleEntity)> GetGamingConsoleForPatchAsync(
          Guid productId, Guid id, bool productTrackChanges, bool gamingConsoleTrackChanges);
    Task SaveChangesForPatchAsync(GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole gamingConsoleEntity);
}
