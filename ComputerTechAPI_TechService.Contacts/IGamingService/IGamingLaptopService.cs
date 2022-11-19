using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingLaptopService
{
    IEnumerable<GamingLaptopDTO> GetGamingLaptops(Guid productId, bool trackChanges);

    GamingLaptopDTO GetGamingLaptop(Guid productId, Guid id, bool trackChanges);
}
