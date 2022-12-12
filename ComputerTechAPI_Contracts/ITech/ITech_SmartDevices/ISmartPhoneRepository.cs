using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDevicesParams;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;

public interface ISmartPhoneRepository
{
    Task<PagedList<SmartPhone>> GetSmartPhonesAsync(Guid productId, SmartPhoneParams smartPhoneParams, bool trackChanges);

    Task<SmartPhone> GetSmartPhoneAsync(Guid productId, Guid id, bool trackChanges);


    void CreateSmartPhoneForProduct(Guid productId, SmartPhone smartPhone);

    void DeleteSmartPhone(SmartPhone smartPhone);
}
