using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_TechService.Contracts.PCService;

public interface IDesktopService
{
    IEnumerable<DesktopDTO> GetDesktops(Guid productId, bool trackChanges);

    DesktopDTO GetDesktop(Guid productId, Guid id, bool trackChanges);
}
