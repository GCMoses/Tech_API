using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IRAMRepository
{
    Task<PagedList<RAM>> GetRAMsAsync(Guid productId, RAMParams ramParams, bool trackChanges);

    Task<RAM> GetRAMAsync(Guid productId, Guid id, bool trackChanges);

    void CreateRAMForProduct(Guid productId, RAM ram);

    void DeleteRAM(RAM ram);
}
