using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Services.PCComponentService;

public class PSUService : IPSUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public PSUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<PSUDTO> GetPSUs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var psuDb = _repository.PSU.GetPSUs(productId, trackChanges);
        var psuDTO = _mapper.Map<IEnumerable<PSUDTO>>(psuDb);
        return psuDTO;
    }


    public PSUDTO GetPSU(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var psuDb = _repository.PSU.GetPSU(productId, id, trackChanges);
        if (psuDb is null)
            throw new PSUNotFoundException(id);

        var psu = _mapper.Map<PSUDTO>(psuDb);
        return psu;
    }


    public PSUDTO CreatePSUForProduct(Guid productId, PSUCreateDTO psuCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var psuEntity = _mapper.Map<PSU>(psuCreate);
        _repository.PSU.CreatePSUForProduct(productId, psuEntity);
        _repository.Save();
        var psuToReturn = _mapper.Map<PSUDTO>(psuEntity);
        return psuToReturn;
    }


    public void DeletePSUForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var psuForProduct = _repository.PSU.GetPSU(productId, id, trackChanges);
        if (psuForProduct is null)
            throw new PSUNotFoundException(id);
        _repository.PSU.DeletePSU(psuForProduct);
        _repository.Save();
    }


    public void UpdatePSUForProduct(Guid productId, Guid id, PSUUpdateDTO psuUpdate,
                                    bool productTrackChanges, bool psuTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var psuEntity = _repository.PSU.GetPSU(productId, id,
        psuTrackChanges);
        if (psuEntity is null)
            throw new PSUNotFoundException(id);
        _mapper.Map(psuUpdate, psuEntity);
        _repository.Save();
    }
}
