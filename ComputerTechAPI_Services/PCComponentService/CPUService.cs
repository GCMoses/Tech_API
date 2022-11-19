using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

namespace ComputerTechAPI_Services.PCComponentService;

public class CPUService : ICPUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public CPUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CPUDTO> GetCPUs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var cpuDb = _repository.CPU.GetCPUs(productId, trackChanges);
        var cpuDTO = _mapper.Map<IEnumerable<CPUDTO>>(cpuDb);
        return cpuDTO;
    }


    public CPUDTO GetCPU(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var cpuDb = _repository.CPU.GetCPU(productId, id, trackChanges);
        if (cpuDb is null)
            throw new CPUNotFoundException(id);

        var cpu = _mapper.Map<CPUDTO>(cpuDb);
        return cpu;
    }
}