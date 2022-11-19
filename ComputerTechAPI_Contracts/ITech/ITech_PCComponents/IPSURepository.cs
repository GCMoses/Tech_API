using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IPSURepository
{
    IEnumerable<PSU> GetPSUs(Guid productId, bool trackChanges);

    PSU GetPSU(Guid productId, Guid id, bool trackChanges);

    void CreatePSU(PSU psu);
}
