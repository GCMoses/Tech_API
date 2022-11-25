using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using AutoMapper;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.Tech_Models.Networking;

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


    public GamingConsoleDTO CreateGamingConsoleForProduct(Guid productId, GamingConsoleCreateDTO gamingConsoleCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingConsoleEntity = _mapper.Map<GamingConsole>(gamingConsoleCreate);
        _repository.GamingConsole.CreateGamingConsoleForProduct(productId, gamingConsoleEntity);
        _repository.Save();
        var gamingConsoleToReturn = _mapper.Map<GamingConsoleDTO>(gamingConsoleEntity);
        return gamingConsoleToReturn;
    }


    public void DeleteGamingConsoleForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingConsoleForProduct = _repository.GamingConsole.GetGamingConsole(productId, id, trackChanges);
        if (gamingConsoleForProduct is null)
            throw new GamingConsoleNotFoundException(id);
        _repository.GamingConsole.DeleteGamingConsole(gamingConsoleForProduct);
        _repository.Save();
    }


    public void UpdateGamingConsoleForProduct(Guid productId, Guid id, GamingConsoleUpdateDTO gamingConsoleUpdate,
                                    bool productTrackChanges, bool gamingConsoleTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingConsoleEntity = _repository.GamingConsole.GetGamingConsole(productId, id,
        gamingConsoleTrackChanges);
        if (gamingConsoleEntity is null)
            throw new GamingConsoleNotFoundException(id);
        _mapper.Map(gamingConsoleUpdate, gamingConsoleEntity);
        _repository.Save();
    }

    public (GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole
        gamingConsoleEntity) GetGamingConsoleForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool gamingConsoleTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingConsoleEntity = _repository.GamingConsole.GetGamingConsole(productId, id,
        gamingConsoleTrackChanges);
        if (gamingConsoleEntity is null)
            throw new GamingConsoleNotFoundException(productId);
        var gamingConsoleToPatch = _mapper.Map<GamingConsoleUpdateDTO>(gamingConsoleEntity);
        return (gamingConsoleToPatch, gamingConsoleEntity);
    }

    public void SaveChangesForPatch(GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole
    gamingConsoleEntity)
    {
        _mapper.Map(gamingConsoleToPatch, gamingConsoleEntity);
        _repository.Save();
    }
}
