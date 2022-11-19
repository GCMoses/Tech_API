using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;

public interface ISmartPhoneRepository
{
    IEnumerable<SmartPhone> GetSmartPhones(Guid productId, bool trackChanges);

    SmartPhone GetSmartPhone(Guid productId, Guid id, bool trackChanges);

    void CreateSmartPhone(SmartPhone smartPhone);
}
