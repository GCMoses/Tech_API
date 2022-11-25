using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IRAMService
{
    IEnumerable<RAMDTO> GetRAMs(Guid productId, bool trackChanges);

    RAMDTO GetRAM(Guid productId, Guid id, bool trackChanges);

    RAMDTO CreateRAMForProduct(Guid productId, RAMCreateDTO ramCreate, bool trackChanges);

    void DeleteRAMForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateRAMForProduct(Guid productId, Guid id, RAMUpdateDTO ramUpdate,
                               bool productTrackChanges, bool ramTrackChanges);


    (RAMUpdateDTO ramToPatch, RAM ramEntity) GetRAMForPatch(
Guid productId, Guid id, bool productTrackChanges, bool ramTrackChanges);
    void SaveChangesForPatch(RAMUpdateDTO ramToPatch, RAM
    ramEntity);
}


