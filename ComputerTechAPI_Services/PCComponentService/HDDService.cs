using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class HDDService : IHDDService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public HDDService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<HDDDTO> GetHDDs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var hddDb = _repository.HDD.GetHDDs(productId, trackChanges);
        var hddDTO = _mapper.Map<IEnumerable<HDDDTO>>(hddDb);
        return hddDTO;
    }


    public HDDDTO GetHDD(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var hddDb = _repository.HDD.GetHDD(productId, id, trackChanges);
        if (hddDb is null)
            throw new HDDNotFoundException(id);

        var hdd = _mapper.Map<HDDDTO>(hddDb);
        return hdd;
    }
}
