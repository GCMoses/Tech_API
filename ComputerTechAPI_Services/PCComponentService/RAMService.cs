using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class RAMService : IRAMService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public RAMService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<RAMDTO> GetRAMs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var ramDb = _repository.RAM.GetRAMs(productId, trackChanges);
        var ramDTO = _mapper.Map<IEnumerable<RAMDTO>>(ramDb);
        return ramDTO;
    }


    public RAMDTO GetRAM(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var ramDb = _repository.RAM.GetRAM(productId, id, trackChanges);
        if (ramDb is null)
            throw new RAMNotFoundException(id);

        var ram = _mapper.Map<RAMDTO>(ramDb);
        return ram;
    }
}