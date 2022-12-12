using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;

public interface IGamingKeyboardRepository
{
    Task<PagedList<GamingKeyboard>> GetGamingKeyboardsAsync(Guid productId,
         GamingKeyboardParams gamingKeyboardParams, bool trackChanges);

    Task<GamingKeyboard> GetGamingKeyboardAsync(Guid productId, Guid id, bool trackChanges);

    void CreateGamingKeyboardForProduct(Guid productId, GamingKeyboard gamingKeyboard);

    void DeleteGamingKeyboard(GamingKeyboard gamingKeyboard);

}
