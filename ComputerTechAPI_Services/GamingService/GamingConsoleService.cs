using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using AutoMapper;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Services.GamingService;

public class GamingConsoleService : IGamingConsoleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GamingConsoleService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<GamingConsoleDTO> GetGamingConsoles(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingConsoleDb = _repository.GamingConsole.GetGamingConsoles(productId, trackChanges);
        var gamingConsoleDTO = _mapper.Map<IEnumerable<GamingConsoleDTO>>(gamingConsoleDb);
        return gamingConsoleDTO;
    }


    public GamingConsoleDTO GetGamingConsole(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingConsoleDb = _repository.GamingConsole.GetGamingConsole(productId, id, trackChanges);
        if (gamingConsoleDb is null)
            throw new GamingConsoleNotFoundException(id);

        var gamingConsole = _mapper.Map<GamingConsoleDTO>(gamingConsoleDb);
        return gamingConsole;
    }

}
