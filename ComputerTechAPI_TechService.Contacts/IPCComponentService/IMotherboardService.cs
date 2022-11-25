using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IMotherboardService
{
    IEnumerable<MotherboardDTO> GetMotherboards(Guid productId, bool trackChanges);

    MotherboardDTO GetMotherboard(Guid productId, Guid id, bool trackChanges);

    MotherboardDTO CreateMotherboardForProduct(Guid productId, MotherboardCreateDTO motherboardCreate, bool trackChanges);

    void DeleteMotherboardForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateMotherboardForProduct(Guid productId, Guid id, MotherboardUpdateDTO motherboardUpdate,
                                 bool productTrackChanges, bool motherboardTrackChanges);


    (MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity) GetMotherboardForPatch(
Guid productId, Guid id, bool productTrackChanges, bool motherboardTrackChanges);
    void SaveChangesForPatch(MotherboardUpdateDTO motherboardToPatch, Motherboard
    motherboardEntity);
}
