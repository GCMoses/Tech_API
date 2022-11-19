using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;

namespace ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

public interface ISmartPhoneService
{
    IEnumerable<SmartPhoneDTO> GetSmartPhones(Guid productId, bool trackChanges);

    SmartPhoneDTO GetSmartPhone(Guid productId, Guid id, bool trackChanges);
}
