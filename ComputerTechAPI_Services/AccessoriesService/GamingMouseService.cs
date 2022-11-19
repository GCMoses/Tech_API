using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;
using AutoMapper;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingMouseService : IGamingMouseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GamingMouseService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<GamingMouseDTO> GetGamingMouses(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingMouseDb = _repository.GamingMouse.GetGamingMouses(productId, trackChanges);
        var gamingMouseDTO = _mapper.Map<IEnumerable<GamingMouseDTO>>(gamingMouseDb);
        return gamingMouseDTO;
    }


    public GamingMouseDTO GetGamingMouse(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingMouseDb = _repository.GamingMouse.GetGamingMouse(productId, id, trackChanges);
        if (gamingMouseDb is null)
            throw new GamingMouseNotFoundException(id);

        var gamingMouse = _mapper.Map<GamingMouseDTO>(gamingMouseDb);
        return gamingMouse;
    }
}