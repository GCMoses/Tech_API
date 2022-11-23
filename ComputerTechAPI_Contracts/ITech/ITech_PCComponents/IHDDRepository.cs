using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IHDDRepository
{
    IEnumerable<HDD> GetHDDs(Guid productId, bool trackChanges);

    HDD GetHDD(Guid productId, Guid id, bool trackChanges);
    void CreateHDDForProduct(Guid productId, HDD hdd);

    void DeleteHDD(HDD hdd);
}
