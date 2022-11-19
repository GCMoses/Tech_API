using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IRAMRepository
{
    IEnumerable<RAM> GetRAMs(Guid productId, bool trackChanges);

    RAM GetRAM(Guid productId, Guid id, bool trackChanges);

    void CreateRAM(RAM ram);
}
