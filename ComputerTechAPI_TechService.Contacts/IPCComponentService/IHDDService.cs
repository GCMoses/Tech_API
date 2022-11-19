using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IHDDService
{
    IEnumerable<HDDDTO> GetHDDs(Guid productId, bool trackChanges);

    HDDDTO GetHDD(Guid productId, Guid id, bool trackChanges);
}
