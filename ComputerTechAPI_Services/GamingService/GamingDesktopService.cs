using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;

namespace ComputerTechAPI_Services.GamingService;

public class GamingDesktopService : IGamingDesktopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GamingDesktopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<GamingDesktopDTO> GetGamingDesktops(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingDesktopDb = _repository.GamingDesktop.GetGamingDesktops(productId, trackChanges);
        var gamingDesktopDTO = _mapper.Map<IEnumerable<GamingDesktopDTO>>(gamingDesktopDb);
        return gamingDesktopDTO;
    }


    public GamingDesktopDTO GetGamingDesktop(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingDesktopDb = _repository.GamingDesktop.GetGamingDesktop(productId, id, trackChanges);
        if (gamingDesktopDb is null)
            throw new GamingConsoleNotFoundException(id);

        var gamingDesktop = _mapper.Map<GamingDesktopDTO>(gamingDesktopDb);
        return gamingDesktop;
    }
}
