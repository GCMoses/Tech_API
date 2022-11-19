using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IMotherboardService
{
    IEnumerable<MotherboardDTO> GetMotherboards(Guid productId, bool trackChanges);

    MotherboardDTO GetMotherboard(Guid productId, Guid id, bool trackChanges);
}
