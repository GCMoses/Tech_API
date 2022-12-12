using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ISSDRepository
{
    Task<PagedList<SSD>> GetSSDsAsync(Guid productId, SSDParams ssdParams, bool trackChanges);

    Task<SSD> GetSSDAsync(Guid productId, Guid id, bool trackChanges);

    void CreateSSDForProduct(Guid productId, SSD ssd);

    void DeleteSSD(SSD ssd);
}
