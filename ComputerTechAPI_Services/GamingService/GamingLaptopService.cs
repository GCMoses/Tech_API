using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using AutoMapper;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models;

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




    public GamingLaptopDTO CreateGamingLaptopForProduct(Guid productId, GamingLaptopCreateDTO gamingLaptop, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingLaptopEntity = _mapper.Map<GamingLaptop>(gamingLaptop);
        _repository.GamingLaptop.CreateGamingLaptopForProduct(productId, gamingLaptopEntity);
        _repository.Save();
        var gamingLaptopToReturn = _mapper.Map<GamingLaptopDTO>(gamingLaptopEntity);
        return gamingLaptopToReturn;
    }


    public void DeleteGamingLaptopForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingLaptopForProduct = _repository.GamingLaptop.GetGamingLaptop(productId, id, trackChanges);
        if (gamingLaptopForProduct is null)
            throw new GamingLaptopNotFoundException(id);
        _repository.GamingLaptop.DeleteGamingLaptop(gamingLaptopForProduct);
        _repository.Save();
    }


    public void UpdateGamingLaptopForProduct(Guid productId, Guid id, GamingLaptopUpdateDTO gamingLaptopUpdate,
                                   bool productTrackChanges, bool gamingLaptopTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingLaptopEntity = _repository.GamingLaptop.GetGamingLaptop(productId, id,
        gamingLaptopTrackChanges);
        if (gamingLaptopEntity is null)
            throw new GamingLaptopNotFoundException(id);
        _mapper.Map(gamingLaptopUpdate, gamingLaptopEntity);
        _repository.Save();
    }

    public (GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop
        gamingLaptopEntity) GetGamingLaptopForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool gamingLaptopTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingLaptopEntity = _repository.GamingLaptop.GetGamingLaptop(productId, id,
        gamingLaptopTrackChanges);
        if (gamingLaptopEntity is null)
            throw new GamingLaptopNotFoundException(productId);
        var gamingLaptopToPatch = _mapper.Map<GamingLaptopUpdateDTO>(gamingLaptopEntity);
        return (gamingLaptopToPatch, gamingLaptopEntity);
    }

    public void SaveChangesForPatch(GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop
    gamingLaptopEntity)
    {
        _mapper.Map(gamingLaptopToPatch, gamingLaptopEntity);
        _repository.Save();
    }
}