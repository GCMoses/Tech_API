using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingDesktopService
{
    IEnumerable<GamingDesktopDTO> GetGamingDesktops(Guid productId, bool trackChanges);

    GamingDesktopDTO GetGamingDesktop(Guid productId, Guid id, bool trackChanges);

    GamingDesktopDTO CreateGamingDesktopForProduct(Guid productId, GamingDesktopCreateDTO gamingDesktopCreate, bool trackChanges);


    void DeleteGamingDesktopForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateGamingDesktopForProduct(Guid productId, Guid id, GamingDesktopUpdateDTO gamingDesktopUpdate,
                                                     bool productTrackChanges, bool gamingDesktopTrackChanges);

    (GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop gamingDesktopEntity) GetGamingDesktopForPatch(
Guid productId, Guid id, bool productTrackChanges, bool gamingDesktopTrackChanges);
    void SaveChangesForPatch(GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop
    gamingDesktopEntity);
}
