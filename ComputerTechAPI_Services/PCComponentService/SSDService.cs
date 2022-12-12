using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.PCComponentService;

public class SSDService : ISSDService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly ISSDLinks _ssdLinks;
    public SSDService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, ISSDLinks ssdLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _ssdLinks = ssdLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetSSDsAsync(Guid productId, SSDLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.ssdParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var ssdsWithMetaData = await _repository.SSD
        .GetSSDsAsync(productId, linkParameters.ssdParams, trackChanges);

        var ssdsDTO = _mapper.Map<IEnumerable<SSDDTO>>
            (ssdsWithMetaData);
        var links = _ssdLinks.TryGenerateLinks(ssdsDTO,
        linkParameters.ssdParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: ssdsWithMetaData.MetaData);
    }


    public async Task<SSDDTO> GetSSDAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var ssdDb = await GetSSDForProductAndCheckIfItExists(productId, id, trackChanges);

        var ssd = _mapper.Map<SSDDTO>(ssdDb);
        return ssd;
    }

    public async Task<SSDDTO> CreateSSDForProductAsync(Guid productId,
        SSDCreateDTO ssdCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var ssdEntity = _mapper.Map<SSD>(ssdCreate);

        _repository.SSD.CreateSSDForProduct(productId, ssdEntity);
        await _repository.SaveAsync();

        var ssdToReturn = _mapper.Map<SSDDTO>(ssdEntity);

        return ssdToReturn;
    }

    public async Task DeleteSSDForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var ssdDb = await GetSSDForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.SSD.DeleteSSD(ssdDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateSSDForProductAsync(Guid productId, Guid id, SSDUpdateDTO ssdUpdate,
                            bool productTrackChanges, bool ssdTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var ssdDb = await GetSSDForProductAndCheckIfItExists(productId, id, ssdTrackChanges);

        _mapper.Map(ssdUpdate, ssdDb);
        await _repository.SaveAsync();
    }

    public async Task<(SSDUpdateDTO ssdToPatch, SSD ssdEntity)> GetSSDForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool ssdTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var ssdDb = await GetSSDForProductAndCheckIfItExists(productId, id, ssdTrackChanges);

        var ssdToPatch = _mapper.Map<SSDUpdateDTO>(ssdDb);

        return (ssdToPatch: ssdToPatch, ssdEntity: ssdDb);
    }

    public async Task SaveChangesForPatchAsync(SSDUpdateDTO ssdToPatch, SSD ssdEntity)
    {
        _mapper.Map(ssdToPatch, ssdEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<SSD> GetSSDForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var ssdDb = await _repository.SSD.GetSSDAsync(productId, id, trackChanges);
        if (ssdDb is null)
            throw new SSDNotFoundException(id);

        return ssdDb;
    }

}
