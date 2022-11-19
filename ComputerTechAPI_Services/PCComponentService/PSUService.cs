using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class PSUService : IPSUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public PSUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<PSUDTO> GetPSUs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var psuDb = _repository.PSU.GetPSUs(productId, trackChanges);
        var psuDTO = _mapper.Map<IEnumerable<PSUDTO>>(psuDb);
        return psuDTO;
    }


    public PSUDTO GetPSU(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var psuDb = _repository.PSU.GetPSU(productId, id, trackChanges);
        if (psuDb is null)
            throw new PSUNotFoundException(id);

        var psu = _mapper.Map<PSUDTO>(psuDb);
        return psu;
    }
}
