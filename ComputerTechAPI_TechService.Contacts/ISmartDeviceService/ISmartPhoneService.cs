using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDevicesParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

public interface ISmartPhoneService
{

    Task<(LinkResponse linkResponse, MetaData metaData)> GetSmartPhonesAsync(Guid productId,
         SmartPhoneLinkParameters linkParameters, bool trackChanges);
    Task<SmartPhoneDTO> GetSmartPhoneAsync(Guid productId, Guid id, bool trackChanges);
    Task<SmartPhoneDTO> CreateSmartPhoneForProductAsync(Guid productId,
       SmartPhoneCreateDTO smartPhoneCreate, bool trackChanges);
    Task DeleteSmartPhoneForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateSmartPhoneForProductAsync(Guid productId, Guid id,
        SmartPhoneUpdateDTO smartPhoneUpdate, bool productTrackChanges, bool smartPhoneTrackChanges);
    Task<(SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone smartPhoneEntity)> GetSmartPhoneForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool smartPhoneTrackChanges);
    Task SaveChangesForPatchAsync(SmartPhoneUpdateDTO SmartPhoneToPatch, SmartPhone smartPhoneEntity);
}
