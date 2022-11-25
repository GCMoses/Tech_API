using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Services.PCComponentService;

public class MotherboardService : IMotherboardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public MotherboardService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<MotherboardDTO> GetMotherboards(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var motherboardDb = _repository.Motherboard.GetMotherboards(productId, trackChanges);
        var motherboardDTO = _mapper.Map<IEnumerable<MotherboardDTO>>(motherboardDb);
        return motherboardDTO;
    }


    public MotherboardDTO GetMotherboard(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var motherboardDb = _repository.Motherboard.GetMotherboard(productId, id, trackChanges);
        if (motherboardDb is null)
            throw new MotherboardNotFoundException(id);

        var motherboard = _mapper.Map<MotherboardDTO>(motherboardDb);
        return motherboard;
    }


    public MotherboardDTO CreateMotherboardForProduct(Guid productId, MotherboardCreateDTO motherboardCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var motherboardEntity = _mapper.Map<Motherboard>(motherboardCreate);
        _repository.Motherboard.CreateMotherboardForProduct(productId, motherboardEntity);
        _repository.Save();
        var motherboardToReturn = _mapper.Map<MotherboardDTO>(motherboardEntity);
        return motherboardToReturn;
    }


    public void DeleteMotherboardForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var motherboardForProduct = _repository.Motherboard.GetMotherboard(productId, id, trackChanges);
        if (motherboardForProduct is null)
            throw new MotherboardNotFoundException(id);
        _repository.Motherboard.DeleteMotherboard(motherboardForProduct);
        _repository.Save();
    }


    public void UpdateMotherboardForProduct(Guid productId, Guid id, MotherboardUpdateDTO motherboardUpdate,
                                            bool productTrackChanges, bool motherboardTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var motherboardEntity = _repository.Motherboard.GetMotherboard(productId, id,
        motherboardTrackChanges);
        if (motherboardEntity is null)
            throw new MotherboardNotFoundException(id);
        _mapper.Map(motherboardUpdate, motherboardEntity);
        _repository.Save();
    }


    public (MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity) GetMotherboardForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool motherboardTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var motherboardEntity = _repository.Motherboard.GetMotherboard(productId, id,
       motherboardTrackChanges);
        if (motherboardEntity is null)
            throw new MotherboardNotFoundException(productId);
        var motherboardToPatch = _mapper.Map<MotherboardUpdateDTO>(motherboardEntity);
        return (motherboardToPatch, motherboardEntity);
    }

    public void SaveChangesForPatch(MotherboardUpdateDTO motherboardToPatch, Motherboard
    motherboardEntity)
    {
        _mapper.Map(motherboardToPatch, motherboardEntity);
        _repository.Save();
    }
}