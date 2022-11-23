using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingDesktopService
{
    IEnumerable<GamingDesktopDTO> GetGamingDesktops(Guid productId, bool trackChanges);

    GamingDesktopDTO GetGamingDesktop(Guid productId, Guid id, bool trackChanges);

    GamingDesktopDTO CreateGamingDesktopForProduct(Guid productId, GamingDesktopCreateDTO gamingDesktopCreate, bool trackChanges);


    void DeleteGamingDesktopForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateGamingDesktopForProduct(Guid productId, Guid id, GamingDesktopUpdateDTO gamingDesktopUpdate,
                                                     bool productTrackChanges, bool gamingDesktopTrackChanges);
}
