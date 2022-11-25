using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

public interface ISmartPhoneService
{
    IEnumerable<SmartPhoneDTO> GetSmartPhones(Guid productId, bool trackChanges);

    SmartPhoneDTO GetSmartPhone(Guid productId, Guid id, bool trackChanges);

    SmartPhoneDTO CreateSmartPhoneForProduct(Guid productId, SmartPhoneCreateDTO smartPhone, bool trackChanges);

    void DeleteSmartPhoneForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateSmartPhoneForProduct(Guid productId, Guid id, SmartPhoneUpdateDTO smartPhoneUpdate,
                                bool productTrackChanges, bool smartPhoneTrackChanges);

    (SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone smartPhoneEntity) GetSmartPhoneForPatch(
Guid productId, Guid id, bool productTrackChanges, bool smartPhoneTrackChanges);
    void SaveChangesForPatch(SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone
    smartPhoneEntity);
}
