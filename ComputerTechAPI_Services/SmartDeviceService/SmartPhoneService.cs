using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

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
}
