using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;

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


    public CPUCoolerDTO CreateCPUCoolerForProduct(Guid productId, CPUCoolerCreateDTO cpuCoolerCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var cpuCoolerEntity = _mapper.Map<CPUCooler>(cpuCoolerCreate);
        _repository.CPUCooler.CreateCPUCoolerForProduct(productId, cpuCoolerEntity);
        _repository.Save();
        var cpuCoolerToReturn = _mapper.Map<CPUCoolerDTO>(cpuCoolerEntity);
        return cpuCoolerToReturn;
    }


    public void DeleteCPUCoolerForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var cpuCoolerForProduct = _repository.CPUCooler.GetCPUCooler(productId, id, trackChanges);
        if (cpuCoolerForProduct is null)
            throw new CPUCoolerNotFoundException(id);
        _repository.CPUCooler.DeleteCPUCooler(cpuCoolerForProduct);
        _repository.Save();
    }


    public void UpdateCPUCoolerForProduct(Guid productId, Guid id, CPUCoolerUpdateDTO cpuCoolerUpdate,
                                       bool productTrackChanges, bool cpuCoolerTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var cpuCoolerEntity = _repository.CPUCooler.GetCPUCooler(productId, id,
        cpuCoolerTrackChanges);
        if (cpuCoolerEntity is null)
            throw new CPUCoolerNotFoundException(id);
        _mapper.Map(cpuCoolerUpdate, cpuCoolerEntity);
        _repository.Save();
    }


    public (CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler cpuCoolerEntity) GetCPUCoolerForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool cpuCoolerTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var cpuCoolerEntity = _repository.CPUCooler.GetCPUCooler(productId, id,
       cpuCoolerTrackChanges);
        if (cpuCoolerEntity is null)
            throw new CPUCoolerNotFoundException(productId);
        var cpuCoolerToPatch = _mapper.Map<CPUCoolerUpdateDTO>(cpuCoolerEntity);
        return (cpuCoolerToPatch, cpuCoolerEntity);
    }

    public void SaveChangesForPatch(CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler
    cpuCoolerEntity)
    {
        _mapper.Map(cpuCoolerToPatch, cpuCoolerEntity);
        _repository.Save();
    }
}