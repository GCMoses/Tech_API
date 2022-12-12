using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICPUService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetCPUsAsync(Guid productId,
        CPULinkParameters linkParameters, bool trackChanges);
    Task<CPUDTO> GetCPUAsync(Guid productId, Guid id, bool trackChanges);
    Task<CPUDTO> CreateCPUForProductAsync(Guid productId,
       CPUCreateDTO cpuCreate, bool trackChanges);
    Task DeleteCPUForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateCPUForProductAsync(Guid productId, Guid id,
        CPUUpdateDTO cpuUpdate, bool productTrackChanges, bool cpuTrackChanges);
    Task<(CPUUpdateDTO cpuToPatch, CPU cpuEntity)> GetCPUForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool cpuTrackChanges);
    Task SaveChangesForPatchAsync(CPUUpdateDTO cpuToPatch, CPU cpuEntity);
}
