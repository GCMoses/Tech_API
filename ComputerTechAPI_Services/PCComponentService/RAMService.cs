using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Services.PCComponentService;

public class RAMService : IRAMService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public RAMService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<RAMDTO> GetRAMs(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var ramDb = _repository.RAM.GetRAMs(productId, trackChanges);
        var ramDTO = _mapper.Map<IEnumerable<RAMDTO>>(ramDb);
        return ramDTO;
    }


    public RAMDTO GetRAM(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var ramDb = _repository.RAM.GetRAM(productId, id, trackChanges);
        if (ramDb is null)
            throw new RAMNotFoundException(id);

        var ram = _mapper.Map<RAMDTO>(ramDb);
        return ram;
    }


    public RAMDTO CreateRAMForProduct(Guid productId, RAMCreateDTO ramCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ramEntity = _mapper.Map<RAM>(ramCreate);
        _repository.RAM.CreateRAMForProduct(productId, ramEntity);
        _repository.Save();
        var ramToReturn = _mapper.Map<RAMDTO>(ramEntity);
        return ramToReturn;
    }


    public void DeleteRAMForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ramForProduct = _repository.RAM.GetRAM(productId, id, trackChanges);
        if (ramForProduct is null)
            throw new RAMNotFoundException(id);
        _repository.RAM.DeleteRAM(ramForProduct);
        _repository.Save();
    }


    public void UpdateRAMForProduct(Guid productId, Guid id, RAMUpdateDTO ramUpdate,
                                  bool productTrackChanges, bool ramTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ramEntity = _repository.RAM.GetRAM(productId, id,
        ramTrackChanges);
        if (ramEntity is null)
            throw new RAMNotFoundException(id);
        _mapper.Map(ramUpdate, ramEntity);
        _repository.Save();
    }


    public (RAMUpdateDTO ramToPatch, RAM ramEntity) GetRAMForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool ramTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var ramEntity = _repository.RAM.GetRAM(productId, id,
       ramTrackChanges);
        if (ramEntity is null)
            throw new RAMNotFoundException(productId);
        var ramToPatch = _mapper.Map<RAMUpdateDTO>(ramEntity);
        return (ramToPatch, ramEntity);
    }

    public void SaveChangesForPatch(RAMUpdateDTO ramToPatch, RAM
    ramEntity)
    {
        _mapper.Map(ramToPatch, ramEntity);
        _repository.Save();
    }

}