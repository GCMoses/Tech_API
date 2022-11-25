using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_TechService.Contracts.PCService;

public interface ILaptopService
{
     IEnumerable<LaptopDTO> GetLaptops(Guid productId, bool trackChanges);

    LaptopDTO GetLaptop(Guid productId, Guid id, bool trackChanges);

    LaptopDTO CreateLaptopForProduct(Guid productId, LaptopCreateDTO laptopCreate, bool trackChanges);

    void DeleteLaptopForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateLaptopForProduct(Guid productId, Guid id, LaptopUpdateDTO laptopUpdate,
                                bool productTrackChanges, bool laptopTrackChanges);

    (LaptopUpdateDTO laptopToPatch, Laptop laptopEntity) GetLaptopForPatch(
Guid productId, Guid id, bool productTrackChanges, bool laptopTrackChanges);
    void SaveChangesForPatch(LaptopUpdateDTO laptopToPatch, Laptop
    laptopEntity);
}
