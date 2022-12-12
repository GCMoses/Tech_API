using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;

public interface IGamingMouseRepository
{
    Task<PagedList<GamingMouse>> GetGamingMousesAsync(Guid productId,
        GamingMouseParams gamingMouseParams, bool trackChanges);

    Task<GamingMouse> GetGamingMouseAsync(Guid productId, Guid id, bool trackChanges);

    void CreateGamingMouseForProduct(Guid productId, GamingMouse gamingMouse);
    void DeleteGamingMouse(GamingMouse gamingMouse);

}
