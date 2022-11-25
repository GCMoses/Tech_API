using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

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


    public GamingDesktopDTO CreateGamingDesktopForProduct(Guid productId, GamingDesktopCreateDTO gamingDesktopCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingDesktopEntity = _mapper.Map<GamingDesktop>(gamingDesktopCreate);
        _repository.GamingDesktop.CreateGamingDesktopForProduct(productId, gamingDesktopEntity);
        _repository.Save();
        var gamingDesktopToReturn = _mapper.Map<GamingDesktopDTO>(gamingDesktopEntity);
        return gamingDesktopToReturn;
    }


    public void DeleteGamingDesktopForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingDesktopForProduct = _repository.GamingDesktop.GetGamingDesktop(productId, id, trackChanges);
        if (gamingDesktopForProduct is null)
            throw new GamingDesktopNotFoundException(id);
        _repository.GamingDesktop.DeleteGamingDesktop(gamingDesktopForProduct);
        _repository.Save();
    }


    public void UpdateGamingDesktopForProduct(Guid productId, Guid id, GamingDesktopUpdateDTO gamingDesktopUpdate,
                                    bool productTrackChanges, bool gamingDesktopTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingDesktopEntity = _repository.GamingDesktop.GetGamingDesktop(productId, id,
        gamingDesktopTrackChanges);
        if (gamingDesktopEntity is null)
            throw new GamingDesktopNotFoundException(id);
        _mapper.Map(gamingDesktopUpdate, gamingDesktopEntity);
        _repository.Save();
    }


    public (GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop
        gamingDesktopEntity) GetGamingDesktopForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool gamingDesktopTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingDesktopEntity = _repository.GamingDesktop.GetGamingDesktop(productId, id,
        gamingDesktopTrackChanges);
        if (gamingDesktopEntity is null)
            throw new GamingDesktopNotFoundException(productId);
        var gamingDesktopToPatch = _mapper.Map<GamingDesktopUpdateDTO>(gamingDesktopEntity);
        return (gamingDesktopToPatch, gamingDesktopEntity);
    }

    public void SaveChangesForPatch(GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop
    gamingDesktopEntity)
    {
        _mapper.Map(gamingDesktopToPatch, gamingDesktopEntity);
        _repository.Save();
    }
}
