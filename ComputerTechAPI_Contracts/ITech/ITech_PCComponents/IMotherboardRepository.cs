using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IMotherboardRepository
{
    Task<PagedList<Motherboard>> GetMotherboardsAsync(Guid productId, MotherboardParams motherboardParams, bool trackChanges);

    Task<Motherboard> GetMotherboardAsync(Guid productId, Guid id, bool trackChanges);
    void CreateMotherboardForProduct(Guid productId, Motherboard motherboard);

    void DeleteMotherboard(Motherboard motherboard);
}
