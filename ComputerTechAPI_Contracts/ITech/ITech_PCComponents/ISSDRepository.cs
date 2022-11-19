using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ISSDRepository
{
    IEnumerable<SSD> GetSSDs(Guid productId, bool trackChanges);

    SSD GetSSD(Guid productId, Guid id, bool trackChanges);

    void CreateSSD(SSD ssd);
}
