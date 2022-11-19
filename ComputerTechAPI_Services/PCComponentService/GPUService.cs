using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

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
}