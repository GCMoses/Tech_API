using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IHDDService
{
    IEnumerable<HDDDTO> GetHDDs(Guid productId, bool trackChanges);

    HDDDTO GetHDD(Guid productId, Guid id, bool trackChanges);

    HDDDTO CreateHDDForProduct(Guid productId, HDDCreateDTO hddCreate, bool trackChanges);

    void DeleteHDDForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateHDDForProduct(Guid productId, Guid id, HDDUpdateDTO hddUpdate,
                                bool productTrackChanges, bool hddTrackChanges);


    (HDDUpdateDTO hddToPatch, HDD hddEntity) GetHDDForPatch(
Guid productId, Guid id, bool productTrackChanges, bool hddTrackChanges);
    void SaveChangesForPatch(HDDUpdateDTO hddToPatch, HDD
    hddEntity);
}
