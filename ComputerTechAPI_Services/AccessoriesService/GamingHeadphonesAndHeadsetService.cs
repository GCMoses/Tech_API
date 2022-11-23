using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingHeadphonesAndHeadsetService : IGamingHeadphonesAndHeadsetService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public GamingHeadphonesAndHeadsetService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<GamingHeadphonesAndHeadsetDTO> GetGamingHeadphonesAndHeadsets(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingHeadphonesAndHeadsetDb = _repository.GamingHeadphonesAndHeadset.GetGamingHeadphonesAndHeadsets(productId, trackChanges);
        var gamingHeadphonesAndHeadsetDTO = _mapper.Map<IEnumerable<GamingHeadphonesAndHeadsetDTO>>(gamingHeadphonesAndHeadsetDb);
        return gamingHeadphonesAndHeadsetDTO;
    }


    public GamingHeadphonesAndHeadsetDTO GetGamingHeadphonesAndHeadset(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var gamingHeadphonesAndHeadsetDb = _repository.GamingHeadphonesAndHeadset.GetGamingHeadphonesAndHeadset(productId, id, trackChanges);
        if (gamingHeadphonesAndHeadsetDb is null)
            throw new GamingHeadphonesAndHeadsetNotFoundException(id);

        var gamingHeadphonesAndHeadset = _mapper.Map<GamingHeadphonesAndHeadsetDTO>(gamingHeadphonesAndHeadsetDb);
        return gamingHeadphonesAndHeadset;
    }



    public GamingHeadphonesAndHeadsetDTO CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadsetCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingHeadphonesAndHeadsetEntity = _mapper.Map<GamingHeadphonesAndHeadset>(gamingHeadphonesAndHeadsetCreate);
        _repository.GamingHeadphonesAndHeadset.CreateGamingHeadphonesAndHeadsetForProduct(productId, gamingHeadphonesAndHeadsetEntity);
        _repository.Save();
        var gamingHeadphonesAndHeadsetToReturn = _mapper.Map<GamingHeadphonesAndHeadsetDTO>(gamingHeadphonesAndHeadsetEntity);
        return gamingHeadphonesAndHeadsetToReturn;
    }


    public void DeleteGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingHeadphonesAndHeadsetForProduct = _repository.GamingHeadphonesAndHeadset.GetGamingHeadphonesAndHeadset(productId, id, trackChanges);
        if (gamingHeadphonesAndHeadsetForProduct is null)
            throw new GamingHeadphonesAndHeadsetNotFoundException(id);
        _repository.GamingHeadphonesAndHeadset.DeleteGamingHeadphonesAndHeadset(gamingHeadphonesAndHeadsetForProduct);
        _repository.Save();
    }


    public void UpdateGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id, GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetUpdate,
                                        bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var gamingHeadphonesAndHeadsetEntity = _repository.GamingHeadphonesAndHeadset.GetGamingHeadphonesAndHeadset(productId, id,
        gamingHeadphonesAndHeadsetTrackChanges);
        if (gamingHeadphonesAndHeadsetEntity is null)
            throw new GamingHeadphonesAndHeadsetNotFoundException(id);
        _mapper.Map(gamingHeadphonesAndHeadsetUpdate, gamingHeadphonesAndHeadsetEntity);
        _repository.Save();
    }


}
