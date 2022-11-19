using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingDesktopService
{
    IEnumerable<GamingDesktopDTO> GetGamingDesktops(Guid productId, bool trackChanges);

    GamingDesktopDTO GetGamingDesktop(Guid productId, Guid id, bool trackChanges);
}
