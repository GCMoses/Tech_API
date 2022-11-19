using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingKeyboardService : IGamingKeyboardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GamingKeyboardService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }



    public IEnumerable<GamingKeyboardDTO> GetGamingKeyboards(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingKeyboardDb = _repository.GamingKeyboard.GetGamingKeyboards(productId, trackChanges);
        var gamingKeyboardDTO = _mapper.Map<IEnumerable<GamingKeyboardDTO>>(gamingKeyboardDb);
        return gamingKeyboardDTO;
    }


    public GamingKeyboardDTO GetGamingKeyboard(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingKeyboardDb = _repository.GamingHeadphonesAndHeadset.GetGamingHeadphonesAndHeadset(productId, id, trackChanges);
        if (gamingKeyboardDb is null)
            throw new GamingKeyboardNotFoundException(id);

        var gamingKeyboard = _mapper.Map<GamingKeyboardDTO>(gamingKeyboardDb);
        return gamingKeyboard;
    }
}