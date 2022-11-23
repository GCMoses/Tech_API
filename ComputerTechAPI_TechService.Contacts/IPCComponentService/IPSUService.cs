using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IPSUService
{
    IEnumerable<PSUDTO> GetPSUs(Guid productId, bool trackChanges);

    PSUDTO GetPSU(Guid productId, Guid id, bool trackChanges);

    PSUDTO CreatePSUForProduct(Guid productId, PSUCreateDTO psuCreate, bool trackChanges);

    void DeletePSUForProduct(Guid productId, Guid id, bool trackChanges);


    void UpdatePSUForProduct(Guid productId, Guid id, PSUUpdateDTO psuUpdate,
                               bool productTrackChanges, bool psuTrackChanges);
}