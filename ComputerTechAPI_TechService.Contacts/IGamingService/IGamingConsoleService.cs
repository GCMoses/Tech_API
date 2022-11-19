using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingConsoleService
{
    IEnumerable<GamingConsoleDTO> GetGamingConsoles(Guid productId, bool trackChanges);

    GamingConsoleDTO GetGamingConsole(Guid productId, Guid id, bool trackChanges);
}
