using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ISSDService
{
    IEnumerable<SSDDTO> GetSSDs(Guid productId, bool trackChanges);

    SSDDTO GetSSD(Guid productId, Guid id, bool trackChanges);

    SSDDTO CreateSSDForProduct(Guid productId, SSDCreateDTO ssdCreate, bool trackChanges);

    void DeleteSSDForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdateSSDForProduct(Guid productId, Guid id, SSDUpdateDTO ssdUpdate,
                                 bool productTrackChanges, bool ssdTrackChanges);


    (SSDUpdateDTO ssdToPatch, SSD ssdEntity) GetSSDForPatch(
Guid productId, Guid id, bool productTrackChanges, bool ssdTrackChanges);
    void SaveChangesForPatch(SSDUpdateDTO ssdToPatch, SSD
    ssdEntity);

}
