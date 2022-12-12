using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IHDDRepository
{
    Task<PagedList<HDD>> GetHDDsAsync(Guid productId, HDDParams hddParams, bool trackChanges);

    Task<HDD> GetHDDAsync(Guid productId, Guid id, bool trackChanges);

    void CreateHDDForProduct(Guid productId, HDD hdd);

    void DeleteHDD(HDD hdd);
}
