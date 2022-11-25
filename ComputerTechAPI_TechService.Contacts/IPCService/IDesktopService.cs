using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.PCService;

public interface IDesktopService
{
    IEnumerable<DesktopDTO> GetDesktops(Guid productId, bool trackChanges);

    DesktopDTO GetDesktop(Guid productId, Guid id, bool trackChanges);

    DesktopDTO CreateDesktopForProduct(Guid productId, DesktopCreateDTO desktopCreate, bool trackChanges);

    void DeleteDesktopForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateDesktopForProduct(Guid productId, Guid id, DesktopUpdateDTO desktopUpdate,
                                   bool productTrackChanges, bool desktopTrackChanges);

    (DesktopUpdateDTO desktopToPatch, Desktop desktopEntity) GetDesktopForPatch(
Guid productId, Guid id, bool productTrackChanges, bool desktopTrackChanges);
    void SaveChangesForPatch(DesktopUpdateDTO desktopToPatch, Desktop
    desktopEntity);
}
