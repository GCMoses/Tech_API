using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Services.PCComponentService;

public class HDDService : IHDDService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public HDDService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<HDDDTO> GetHDDs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var hddDb = _repository.HDD.GetHDDs(productId, trackChanges);
        var hddDTO = _mapper.Map<IEnumerable<HDDDTO>>(hddDb);
        return hddDTO;
    }


    public HDDDTO GetHDD(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var hddDb = _repository.HDD.GetHDD(productId, id, trackChanges);
        if (hddDb is null)
            throw new HDDNotFoundException(id);

        var hdd = _mapper.Map<HDDDTO>(hddDb);
        return hdd;
    }


    public HDDDTO CreateHDDForProduct(Guid productId, HDDCreateDTO hddCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var hddEntity = _mapper.Map<HDD>(hddCreate);
        _repository.HDD.CreateHDDForProduct(productId, hddEntity);
        _repository.Save();
        var hddToReturn = _mapper.Map<HDDDTO>(hddEntity);
        return hddToReturn;
    }


    public void DeleteHDDForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var hddForProduct = _repository.HDD.GetHDD(productId, id, trackChanges);
        if (hddForProduct is null)
            throw new HDDNotFoundException(id);
        _repository.HDD.DeleteHDD(hddForProduct);
        _repository.Save();
    }


    public void UpdateHDDForProduct(Guid productId, Guid id, HDDUpdateDTO hddUpdate,
                                    bool productTrackChanges, bool hddTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var hddEntity = _repository.HDD.GetHDD(productId, id,
        hddTrackChanges);
        if (hddEntity is null)
            throw new HDDNotFoundException(id);
        _mapper.Map(hddUpdate, hddEntity);
        _repository.Save();
    }


    public (HDDUpdateDTO hddToPatch, HDD hddEntity) GetHDDForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool hddTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var hddEntity = _repository.HDD.GetHDD(productId, id,
       hddTrackChanges);
        if (hddEntity is null)
            throw new HDDNotFoundException(productId);
        var hddToPatch = _mapper.Map<HDDUpdateDTO>(hddEntity);
        return (hddToPatch, hddEntity);
    }

    public void SaveChangesForPatch(HDDUpdateDTO hddToPatch, HDD
    hddEntity)
    {
        _mapper.Map(hddToPatch, hddEntity);
        _repository.Save();
    }
}