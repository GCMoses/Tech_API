using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_TechService.Contracts.PCService;

public interface ILaptopService
{
     IEnumerable<LaptopDTO> GetLaptops(Guid productId, bool trackChanges);

    LaptopDTO GetLaptop(Guid productId, Guid id, bool trackChanges);
}
