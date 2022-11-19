using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingHeadphonesAndHeadsetService
{
    IEnumerable<GamingHeadphonesAndHeadsetDTO> GetGamingHeadphonesAndHeadsets(Guid productId, bool trackChanges);
    GamingHeadphonesAndHeadsetDTO GetGamingHeadphonesAndHeadset(Guid productId, Guid id, bool trackChanges);
}
