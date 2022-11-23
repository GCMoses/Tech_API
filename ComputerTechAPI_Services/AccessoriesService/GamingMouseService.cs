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


    

    public GamingMouseDTO CreateGamingMouseForProduct(Guid productId, GamingMouseCreateDTO gamingMouseCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingMouseEntity = _mapper.Map<GamingMouse>(gamingMouseCreate);
        _repository.GamingMouse.CreateGamingMouseForProduct(productId, gamingMouseEntity);
        _repository.Save();
        var gamingMouseToReturn = _mapper.Map<GamingMouseDTO>(gamingMouseEntity);
        return gamingMouseToReturn;
    }


    public void DeleteGamingMouseForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingMouseForProduct = _repository.GamingMouse.GetGamingMouse(productId, id, trackChanges);
        if (gamingMouseForProduct is null)
            throw new GamingMouseNotFoundException(id);
        _repository.GamingMouse.DeleteGamingMouse(gamingMouseForProduct);
        _repository.Save();
    }


    public void UpdateGamingMouseForProduct(Guid productId, Guid id, GamingMouseUpdateDTO gamingMouseUpdate,
                                        bool productTrackChanges, bool gamingMouseTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingMouseEntity = _repository.GamingMouse.GetGamingMouse(productId, id,
        gamingMouseTrackChanges);
        if (gamingMouseEntity is null)
            throw new GamingMouseNotFoundException(id);
        _mapper.Map(gamingMouseUpdate, gamingMouseEntity);
        _repository.Save();
    }
}