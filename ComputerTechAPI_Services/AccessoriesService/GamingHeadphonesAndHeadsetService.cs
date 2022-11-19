using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
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
}
