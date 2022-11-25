using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingLaptopService
{
    IEnumerable<GamingLaptopDTO> GetGamingLaptops(Guid productId, bool trackChanges);

    GamingLaptopDTO GetGamingLaptop(Guid productId, Guid id, bool trackChanges);

    GamingLaptopDTO CreateGamingLaptopForProduct(Guid productId, GamingLaptopCreateDTO gamingLaptopCreate, bool trackChanges);

    void DeleteGamingLaptopForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateGamingLaptopForProduct(Guid productId, Guid id, GamingLaptopUpdateDTO gamingLaptopUpdate,
                                                     bool productTrackChanges, bool gamingLaptopTrackChanges);

    (GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop gamingLaptopEntity) GetGamingLaptopForPatch(
Guid productId, Guid id, bool productTrackChanges, bool gamingLaptopTrackChanges);
    void SaveChangesForPatch(GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop
    gamingLaptopEntity);
}
