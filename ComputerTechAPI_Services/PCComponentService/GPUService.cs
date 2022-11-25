using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Services.PCComponentService;

public class GPUService : IGPUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GPUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<GPUDTO> GetGPUs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gpuDb = _repository.GPU.GetGPUs(productId, trackChanges);
        var gpuDTO = _mapper.Map<IEnumerable<GPUDTO>>(gpuDb);
        return gpuDTO;
    }


    public GPUDTO GetGPU(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gpuDb = _repository.GPU.GetGPU(productId, id, trackChanges);
        if (gpuDb is null)
            throw new GPUNotFoundException(id);

        var gpu = _mapper.Map<GPUDTO>(gpuDb);
        return gpu;
    }

    public GPUDTO CreateGPUForProduct(Guid productId, GPUCreateDTO gpuCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gpuEntity = _mapper.Map<GPU>(gpuCreate);
        _repository.GPU.CreateGPUForProduct(productId, gpuEntity);
        _repository.Save();
        var gpuToReturn = _mapper.Map<GPUDTO>(gpuEntity);
        return gpuToReturn;
    }


    public void DeleteGPUForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gpuForProduct = _repository.GPU.GetGPU(productId, id, trackChanges);
        if (gpuForProduct is null)
            throw new GPUNotFoundException(id);
        _repository.GPU.DeleteGPU(gpuForProduct);
        _repository.Save();
    }


    public void UpdateGPUForProduct(Guid productId, Guid id, GPUUpdateDTO gpuUpdate,
                                      bool productTrackChanges, bool gpuTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gpuEntity = _repository.GPU.GetGPU(productId, id,
        gpuTrackChanges);
        if (gpuEntity is null)
            throw new GPUNotFoundException(id);
        _mapper.Map(gpuUpdate, gpuEntity);
        _repository.Save();
    }


    public (GPUUpdateDTO gpuToPatch, GPU gpuEntity) GetGPUForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool gpuTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gpuEntity = _repository.GPU.GetGPU(productId, id,
       gpuTrackChanges);
        if (gpuEntity is null)
            throw new GPUNotFoundException(productId);
        var gpuToPatch = _mapper.Map<GPUUpdateDTO>(gpuEntity);
        return (gpuToPatch, gpuEntity);
    }

    public void SaveChangesForPatch(GPUUpdateDTO gpuToPatch, GPU
    gpuEntity)
    {
        _mapper.Map(gpuToPatch, gpuEntity);
        _repository.Save();
    }
}
