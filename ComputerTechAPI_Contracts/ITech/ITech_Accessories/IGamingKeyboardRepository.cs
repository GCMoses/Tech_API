using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Contracts.ITech.ITech_Accessories;

public interface IGamingKeyboardRepository
{
    IEnumerable<GamingKeyboard> GetGamingKeyboards(Guid productId, bool trackChanges);

    GamingKeyboard GetGamingKeyboard(Guid productId, Guid id, bool trackChanges);

    void CreateGamingKeyboardForProduct(Guid productId, GamingKeyboard gamingKeyboard);

    void DeleteGamingKeyboard(GamingKeyboard gamingKeyboard);

}
