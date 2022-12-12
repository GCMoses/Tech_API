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

public class PSUService : IPSUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IPSULinks _psuLinks;
    public PSUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IPSULinks psuLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _psuLinks = psuLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetPSUsAsync(Guid productId, PSULinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.psuParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var psusWithMetaData = await _repository.PSU
        .GetPSUsAsync(productId, linkParameters.psuParams, trackChanges);

        var psusDTO = _mapper.Map<IEnumerable<PSUDTO>>
            (psusWithMetaData);
        var links = _psuLinks.TryGenerateLinks(psusDTO,
        linkParameters.psuParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: psusWithMetaData.MetaData);
    }


    public async Task<PSUDTO> GetPSUAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var psuDb = await GetPSUForProductAndCheckIfItExists(productId, id, trackChanges);

        var psuDTO = _mapper.Map<PSUDTO>(psuDb);
        return psuDTO;
    }


    public async Task<PSUDTO> CreatePSUForProductAsync(Guid productId,
        PSUCreateDTO psuCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var psuEntity = _mapper.Map<PSU>(psuCreate);

        _repository.PSU.CreatePSUForProduct(productId, psuEntity);
        await _repository.SaveAsync();

        var psuToReturn = _mapper.Map<PSUDTO>(psuEntity);

        return psuToReturn;
    }

    public async Task DeletePSUForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var psuDb = await GetPSUForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.PSU.DeletePSU(psuDb);
        await _repository.SaveAsync();
    }

    public async Task UpdatePSUForProductAsync(Guid productId, Guid id, PSUUpdateDTO psuUpdate,
                                               bool productTrackChanges, bool psuTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var psuDb = await GetPSUForProductAndCheckIfItExists(productId, id, psuTrackChanges);

        _mapper.Map(psuUpdate, psuDb);
        await _repository.SaveAsync();
    }

    public async Task<(PSUUpdateDTO psuToPatch, PSU psuEntity)> GetPSUForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool psuTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var psuDb = await GetPSUForProductAndCheckIfItExists(productId, id, psuTrackChanges);

        var psuToPatch = _mapper.Map<PSUUpdateDTO>(psuDb);

        return (psuToPatch: psuToPatch, psuEntity: psuDb);
    }

    public async Task SaveChangesForPatchAsync(PSUUpdateDTO psuToPatch, PSU psuEntity)
    {
        _mapper.Map(psuToPatch, psuEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<PSU> GetPSUForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var psuDb = await _repository.PSU.GetPSUAsync(productId, id, trackChanges);
        if (psuDb is null)
            throw new PSUNotFoundException(id);

        return psuDb;
    }


}
