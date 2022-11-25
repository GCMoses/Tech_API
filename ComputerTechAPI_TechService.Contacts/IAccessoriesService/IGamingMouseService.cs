using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IAccessoriesService;

public interface IGamingMouseService
{
    IEnumerable<GamingMouseDTO> GetGamingMouses(Guid productId, bool trackChanges);
    GamingMouseDTO GetGamingMouse(Guid productId, Guid id, bool trackChanges);

    GamingMouseDTO CreateGamingMouseForProduct(Guid productId, GamingMouseCreateDTO gamingMouseCreate, bool trackChanges);

    void DeleteGamingMouseForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateGamingMouseForProduct(Guid productId, Guid id, GamingMouseUpdateDTO gamingMouseUpdate,
                                                    bool productTrackChanges, bool gamingMouseTrackChanges);

    (GamingMouseUpdateDTO gamingMouseToPatch, GamingMouse gamingMouseEntity) GetGamingMouseForPatch(
Guid productId, Guid id, bool productTrackChanges, bool gamingMouseTrackChanges);
    void SaveChangesForPatch(GamingMouseUpdateDTO gamingMouseToPatch, GamingMouse
    gamingMouseEntity);
}


