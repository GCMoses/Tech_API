using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.SmartDeviceService;

public class SmartPhoneService : ISmartPhoneService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly ISmartPhoneLinks _smartPhoneLinks;
    public SmartPhoneService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, ISmartPhoneLinks smartPhoneLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _smartPhoneLinks = smartPhoneLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetSmartPhonesAsync(Guid productId, SmartPhoneLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.smartPhoneParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var smartPhonesWithMetaData = await _repository.SmartPhone
        .GetSmartPhonesAsync(productId, linkParameters.smartPhoneParams, trackChanges);

        var smartPhoneDTO = _mapper.Map<IEnumerable<SmartPhoneDTO>>
            (smartPhonesWithMetaData);
        var links = _smartPhoneLinks.TryGenerateLinks(smartPhoneDTO,
        linkParameters.smartPhoneParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: smartPhonesWithMetaData.MetaData);
    }
    public async Task<SmartPhoneDTO> GetSmartPhoneAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var smartPhoneDb = await GetSmartPhoneForProductAndCheckIfItExists(productId, id, trackChanges);

        var smartPhoneDTO = _mapper.Map<SmartPhoneDTO>(smartPhoneDb);
        return smartPhoneDTO;
    }

    public async Task<SmartPhoneDTO> CreateSmartPhoneForProductAsync(Guid productId,
        SmartPhoneCreateDTO smartPhoneCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var smartPhoneEntity = _mapper.Map<SmartPhone>(smartPhoneCreate);

        _repository.SmartPhone.CreateSmartPhoneForProduct(productId, smartPhoneEntity);
        await _repository.SaveAsync();

        var smartPhoneToReturn = _mapper.Map<SmartPhoneDTO>(smartPhoneEntity);

        return smartPhoneToReturn;
    }

    public async Task DeleteSmartPhoneForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var smartPhoneDb = await GetSmartPhoneForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.SmartPhone.DeleteSmartPhone(smartPhoneDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateSmartPhoneForProductAsync(Guid productId, Guid id, SmartPhoneUpdateDTO
        smartPhoneUpdate, bool productTrackChanges, bool smartPhoneTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var smartPhoneDb = await GetSmartPhoneForProductAndCheckIfItExists(productId, id, smartPhoneTrackChanges);

        _mapper.Map(smartPhoneUpdate, smartPhoneDb);
        await _repository.SaveAsync();
    }

    public async Task<(SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone smartPhoneEntity)> GetSmartPhoneForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool smartPhoneTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var smartPhoneDb = await GetSmartPhoneForProductAndCheckIfItExists(productId, id, smartPhoneTrackChanges);

        var smartPhoneToPatch = _mapper.Map<SmartPhoneUpdateDTO>(smartPhoneDb);

        return (smartPhoneToPatch: smartPhoneToPatch, smartPhoneEntity: smartPhoneDb);
    }

    public async Task SaveChangesForPatchAsync(SmartPhoneUpdateDTO smartPhoneToPatch, SmartPhone smartPhoneEntity)
    {
        _mapper.Map(smartPhoneToPatch, smartPhoneEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<SmartPhone> GetSmartPhoneForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var smartPhoneDb = await _repository.SmartPhone.GetSmartPhoneAsync(productId, id, trackChanges);
        if (smartPhoneDb is null)
            throw new SmartPhoneNotFoundException(id);

        return smartPhoneDb;
    }

}
