using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingMouseService
{
    IEnumerable<GamingMouseDTO> GetGamingMouses(Guid productId, bool trackChanges);
    GamingMouseDTO GetGamingMouse(Guid productId, Guid id, bool trackChanges);
}


