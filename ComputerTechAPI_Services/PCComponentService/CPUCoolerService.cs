using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class CPUCoolerService : ICPUCoolerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public CPUCoolerService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CPUCoolerDTO> GetCPUCoolers(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var cpuCoolerDb = _repository.CPUCooler.GetCPUCoolers(productId, trackChanges);
        var cpuCoolerDTO = _mapper.Map<IEnumerable<CPUCoolerDTO>>(cpuCoolerDb);
        return cpuCoolerDTO;
    }


    public CPUCoolerDTO GetCPUCooler(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var cpuCoolerDb = _repository.CPUCooler.GetCPUCooler(productId, id, trackChanges);
        if (cpuCoolerDb is null)
            throw new CPUCoolerNotFoundException(id);

        var cpuCooler = _mapper.Map<CPUCoolerDTO>(cpuCoolerDb);
        return cpuCooler;
    }
}