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


   

    public GamingKeyboardDTO CreateGamingKeyboardForProduct(Guid productId, GamingKeyboardCreateDTO gamingKeyboardCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingKeyboardEntity = _mapper.Map<GamingKeyboard>(gamingKeyboardCreate);
        _repository.GamingKeyboard.CreateGamingKeyboardForProduct(productId, gamingKeyboardEntity);
        _repository.Save();
        var gamingKeyboardToReturn = _mapper.Map<GamingKeyboardDTO>(gamingKeyboardEntity);
        return gamingKeyboardToReturn;
    }


    public void DeleteGamingKeyboardForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingKeyboardForProduct = _repository.GamingKeyboard.GetGamingKeyboard(productId, id, trackChanges);
        if (gamingKeyboardForProduct is null)
            throw new GamingKeyboardNotFoundException(id);
        _repository.GamingKeyboard.DeleteGamingKeyboard(gamingKeyboardForProduct);
        _repository.Save();
    }


    public void UpdateGamingKeyboardForProduct(Guid productId, Guid id, GamingKeyboardUpdateDTO gamingKeyboardUpdate,
                                        bool productTrackChanges, bool gamingKeyboardTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingKeyboardEntity = _repository.GamingKeyboard.GetGamingKeyboard(productId, id,
        gamingKeyboardTrackChanges);
        if (gamingKeyboardEntity is null)
            throw new GamingKeyboardNotFoundException(id);
        _mapper.Map(gamingKeyboardUpdate, gamingKeyboardEntity);
        _repository.Save();
    }
}