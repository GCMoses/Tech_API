using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IHDDRepository
{
    IEnumerable<HDD> GetHDDs(Guid productId, bool trackChanges);

    HDD GetHDD(Guid productId, Guid id, bool trackChanges);
    void CreateHDD(HDD hdd);
}
