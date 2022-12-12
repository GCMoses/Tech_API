using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IGPUService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGPUsAsync(Guid productId,
            GPULinkParameters linkParameters, bool trackChanges);
    Task<GPUDTO> GetGPUAsync(Guid productId, Guid id, bool trackChanges);
    Task<GPUDTO> CreateGPUForProductAsync(Guid productId,
       GPUCreateDTO gpuCreate, bool trackChanges);
    Task DeleteGPUForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGPUForProductAsync(Guid productId, Guid id,
        GPUUpdateDTO gpuUpdate, bool productTrackChanges, bool gpuTrackChanges);
    Task<(GPUUpdateDTO gpuToPatch, GPU gpuEntity)> GetGPUForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool gpuTrackChanges);
    Task SaveChangesForPatchAsync(GPUUpdateDTO gpuToPatch, GPU gpuEntity);
}

