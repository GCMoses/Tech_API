using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Services.PCComponentService;

public class SSDService : ISSDService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public SSDService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<SSDDTO> GetSSDs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var ssdDb = _repository.SSD.GetSSDs(productId, trackChanges);
        var ssdDTO = _mapper.Map<IEnumerable<SSDDTO>>(ssdDb);
        return ssdDTO;
    }


    public SSDDTO GetSSD(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var ssdDb = _repository.SSD.GetSSD(productId, id, trackChanges);
        if (ssdDb is null)
            throw new SSDNotFoundException(id);

        var ssd = _mapper.Map<SSDDTO>(ssdDb);
        return ssd;
    }


    public SSDDTO CreateSSDForProduct(Guid productId, SSDCreateDTO ssdCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ssdEntity = _mapper.Map<SSD>(ssdCreate);
        _repository.SSD.CreateSSDForProduct(productId, ssdEntity);
        _repository.Save();
        var ssdToReturn = _mapper.Map<SSDDTO>(ssdEntity);
        return ssdToReturn;
    }


    public void DeleteSSDForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ssdForProduct = _repository.SSD.GetSSD(productId, id, trackChanges);
        if (ssdForProduct is null)
            throw new SSDNotFoundException(id);
        _repository.SSD.DeleteSSD(ssdForProduct);
        _repository.Save();
    }


    public void UpdateSSDForProduct(Guid productId, Guid id, SSDUpdateDTO ssdUpdate,
                                   bool productTrackChanges, bool ssdTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ssdEntity = _repository.SSD.GetSSD(productId, id,
        ssdTrackChanges);
        if (ssdEntity is null)
            throw new SSDNotFoundException(id);
        _mapper.Map(ssdUpdate, ssdEntity);
        _repository.Save();
    }
}
