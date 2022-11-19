using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IRAMService
{
    IEnumerable<RAMDTO> GetRAMs(Guid productId, bool trackChanges);

    RAMDTO GetRAM(Guid productId, Guid id, bool trackChanges);
}
