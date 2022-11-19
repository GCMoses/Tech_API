using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using AutoMapper;

namespace ComputerTechAPI_Services.GamingService;

public class GamingLaptopService : IGamingLaptopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GamingLaptopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<GamingLaptopDTO> GetGamingLaptops(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingLaptopDb = _repository.GamingLaptop.GetGamingLaptops(productId, trackChanges);
        var gamingLaptopDTO = _mapper.Map<IEnumerable<GamingLaptopDTO>>(gamingLaptopDb);
        return gamingLaptopDTO;
    }


    public GamingLaptopDTO GetGamingLaptop(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingLaptopDb = _repository.GamingLaptop.GetGamingLaptop(productId, id, trackChanges);
        if (gamingLaptopDb is null)
            throw new GamingLaptopNotFoundException(id);

        var gamingLaptop = _mapper.Map<GamingLaptopDTO>(gamingLaptopDb);
        return gamingLaptop;
    }   
}