using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingConsoleService
{
    IEnumerable<GamingConsoleDTO> GetGamingConsoles(Guid productId, bool trackChanges);

    GamingConsoleDTO GetGamingConsole(Guid productId, Guid id, bool trackChanges);

    GamingConsoleDTO CreateGamingConsoleForProduct(Guid productId, GamingConsoleCreateDTO gamingConsoleCreate, bool trackChanges);


    void DeleteGamingConsoleForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateGamingConsoleForProduct(Guid productId, Guid id, GamingConsoleUpdateDTO gamingConsoleUpdate,
                                       bool productTrackChanges, bool gamingConsoleTrackChanges);

    (GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole gamingConsoleEntity) GetGamingConsoleForPatch(
Guid productId, Guid id, bool productTrackChanges, bool gamingConsoleTrackChanges);
    void SaveChangesForPatch(GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole
    gamingConsoleEntity);
}
