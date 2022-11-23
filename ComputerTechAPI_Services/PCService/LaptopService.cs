using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.PCService;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.PCService;

public class LaptopService : ILaptopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public LaptopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<LaptopDTO> GetLaptops(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var laptopDb = _repository.Laptop.GetLaptops(productId, trackChanges);
        var laptopDTO = _mapper.Map<IEnumerable<LaptopDTO>>(laptopDb);
        return laptopDTO;
    }


    public LaptopDTO GetLaptop(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var laptopDb = _repository.Laptop.GetLaptop(productId, id, trackChanges);
        if (laptopDb is null)
            throw new LaptopNotFoundException(id);

        var laptop = _mapper.Map<LaptopDTO>(laptopDb);
        return laptop;
    }

    public LaptopDTO CreateLaptopForProduct(Guid productId, LaptopCreateDTO laptop, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    var laptopEntity = _mapper.Map<Laptop>(laptop);
    _repository.Laptop.CreateLaptopForProduct(productId, laptopEntity);
        _repository.Save();
        var laptopToReturn = _mapper.Map<LaptopDTO>(laptopEntity);
        return laptopToReturn;
    }


    public void DeleteLaptopForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var laptopForProduct = _repository.Laptop.GetLaptop(productId, id, trackChanges);
        if (laptopForProduct is null)
            throw new LaptopNotFoundException(id);
        _repository.Laptop.DeleteLaptop(laptopForProduct);
        _repository.Save();
    }


    public void UpdateLaptopForProduct(Guid productId, Guid id, LaptopUpdateDTO laptopUpdate,
                                   bool productTrackChanges, bool laptopTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var laptopEntity = _repository.Laptop.GetLaptop(productId, id,
        laptopTrackChanges);
        if (laptopEntity is null)
            throw new LaptopNotFoundException(id);
        _mapper.Map(laptopUpdate, laptopEntity);
        _repository.Save();
    }
}