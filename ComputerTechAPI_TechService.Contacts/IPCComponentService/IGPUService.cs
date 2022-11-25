using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IGPUService
{
    IEnumerable<GPUDTO> GetGPUs(Guid productId, bool trackChanges);

    GPUDTO GetGPU(Guid productId, Guid id, bool trackChanges);

    GPUDTO CreateGPUForProduct(Guid productId, GPUCreateDTO gpuCreate, bool trackChanges);

    void DeleteGPUForProduct(Guid productId, Guid id, bool trackChanges);

    void UpdateGPUForProduct(Guid productId, Guid id, GPUUpdateDTO gpuUpdate,
                                bool productTrackChanges, bool gpuTrackChanges);


    (GPUUpdateDTO gpuToPatch, GPU gpuEntity) GetGPUForPatch(
Guid productId, Guid id, bool productTrackChanges, bool gpuTrackChanges);
    void SaveChangesForPatch(GPUUpdateDTO gpuToPatch, GPU
    gpuEntity);
}
