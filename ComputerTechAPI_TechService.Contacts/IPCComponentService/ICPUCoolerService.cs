using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface ICPUCoolerService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetCPUCoolersAsync(Guid productId,
        CPUCoolerLinkParameters linkParameters, bool trackChanges);
    Task<CPUCoolerDTO> GetCPUCoolerAsync(Guid productId, Guid id, bool trackChanges);
    Task<CPUCoolerDTO> CreateCPUCoolerForProductAsync(Guid productId,
       CPUCoolerCreateDTO cpuCoolerCreate, bool trackChanges);
    Task DeleteCPUCoolerForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateCPUCoolerForProductAsync(Guid productId, Guid id,
        CPUCoolerUpdateDTO cpuCoolerUpdate, bool productTrackChanges, bool cpuCoolerTrackChanges);
    Task<(CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler cpuCoolerEntity)> GetCPUCoolerForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool cpuCoolerTrackChanges);
    Task SaveChangesForPatchAsync(CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler cpuCoolerEntity);
}

