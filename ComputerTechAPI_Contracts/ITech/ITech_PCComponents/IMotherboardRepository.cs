using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IMotherboardRepository
{
    IEnumerable<Motherboard> GetMotherboards(Guid productId, bool trackChanges);

    Motherboard GetMotherboard(Guid productId, Guid id, bool trackChanges);

    void CreateMotherboard(Motherboard motherboard);
}
