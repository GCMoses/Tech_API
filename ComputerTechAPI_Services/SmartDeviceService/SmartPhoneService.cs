using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Services.PCSeSmartDeviceServicervice;

public class SmartPhoneService : ISmartPhoneService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public SmartPhoneService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<SmartPhoneDTO> GetSmartPhones(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var smartPhoneDb = _repository.SmartPhone.GetSmartPhones(productId, trackChanges);
        var smartPhoneDTO = _mapper.Map<IEnumerable<SmartPhoneDTO>>(smartPhoneDb);
        return smartPhoneDTO;
    }


    public SmartPhoneDTO GetSmartPhone(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var droneDb = _repository.SmartPhone.GetSmartPhone(productId, id, trackChanges);
        if (droneDb is null)
            throw new DroneNotFoundException(id);

        var smartPhone = _mapper.Map<SmartPhoneDTO>(droneDb);
        return smartPhone;
    }


    public SmartPhoneDTO CreateSmartPhoneForProduct(Guid productId, SmartPhoneCreateDTO smartPhone, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var smartPhoneEntity = _mapper.Map<SmartPhone>(smartPhone);
        _repository.SmartPhone.CreateSmartPhoneForProduct(productId, smartPhoneEntity);
        _repository.Save();
        var smartPhoneToReturn = _mapper.Map<SmartPhoneDTO>(smartPhoneEntity);
        return smartPhoneToReturn;
    }


    public void DeleteSmartPhoneForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var smartPhoneForProduct = _repository.SmartPhone.GetSmartPhone(productId, id, trackChanges);
        if (smartPhoneForProduct is null)
            throw new SmartPhoneNotFoundException(id);
        _repository.SmartPhone.DeleteSmartPhone(smartPhoneForProduct);
        _repository.Save();
    }


    public void UpdateSmartPhoneForProduct(Guid productId, Guid id, SmartPhoneUpdateDTO smartPhoneUpdate,
                                 bool productTrackChanges, bool smartPhoneTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var smartPhoneEntity = _repository.SmartPhone.GetSmartPhone(productId, id,
        smartPhoneTrackChanges);
        if (smartPhoneEntity is null)
            throw new SmartPhoneNotFoundException(id);
        _mapper.Map(smartPhoneUpdate, smartPhoneEntity);
        _repository.Save();
    }


    public (SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone smartPhoneEntity) GetSmartPhoneForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool smartPhoneTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var smartPhoneEntity = _repository.SmartPhone.GetSmartPhone(productId, id,
       smartPhoneTrackChanges);
        if (smartPhoneEntity is null)
            throw new SmartPhoneNotFoundException(productId);
        var smartPhoneToPatch = _mapper.Map<SmartPhoneUpdateDTO>(smartPhoneEntity);
        return (smartPhoneToPatch, smartPhoneEntity);
    }

    public void SaveChangesForPatch(SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone
        smartPhoneEntity)
    {
        _mapper.Map(smartPhoneToPatch, smartPhoneEntity);
        _repository.Save();
    }

}
