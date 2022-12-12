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

public class HDDService : IHDDService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IHDDLinks _hddLinks;
    public HDDService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IHDDLinks hddLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _hddLinks = hddLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetHDDsAsync(Guid productId, HDDLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.hddParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var hddsWithMetaData = await _repository.HDD
        .GetHDDsAsync(productId, linkParameters.hddParams, trackChanges);

        var hddsDTO = _mapper.Map<IEnumerable<HDDDTO>>
            (hddsWithMetaData);
        var links = _hddLinks.TryGenerateLinks(hddsDTO,
        linkParameters.hddParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: hddsWithMetaData.MetaData);
    }

    public async Task<HDDDTO> GetHDDAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var hddDb = await GetHDDForProductAndCheckIfItExists(productId, id, trackChanges);

        var hddDTO = _mapper.Map<HDDDTO>(hddDb);
        return hddDTO;
    }


    public async Task<HDDDTO> CreateHDDForProductAsync(Guid productId,
        HDDCreateDTO hddCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var hddEntity = _mapper.Map<HDD>(hddCreate);

        _repository.HDD.CreateHDDForProduct(productId, hddEntity);
        await _repository.SaveAsync();

        var hddToReturn = _mapper.Map<HDDDTO>(hddEntity);

        return hddToReturn;
    }

    public async Task DeleteHDDForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var hddDb = await GetHDDForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.HDD.DeleteHDD(hddDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateHDDForProductAsync(Guid productId, Guid id, HDDUpdateDTO hddUpdate,
                                               bool productTrackChanges, bool hddTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var hddDb = await GetHDDForProductAndCheckIfItExists(productId, id, hddTrackChanges);

        _mapper.Map(hddUpdate, hddDb);
        await _repository.SaveAsync();
    }

    public async Task<(HDDUpdateDTO hddToPatch, HDD hddEntity)> GetHDDForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool hddTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var hddDb = await GetHDDForProductAndCheckIfItExists(productId, id, hddTrackChanges);

        var hddToPatch = _mapper.Map<HDDUpdateDTO>(hddDb);

        return (hddToPatch: hddToPatch, hddEntity: hddDb);
    }

    public async Task SaveChangesForPatchAsync(HDDUpdateDTO hddToPatch, HDD hddEntity)
    {
        _mapper.Map(hddToPatch, hddEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<HDD> GetHDDForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var hddDb = await _repository.HDD.GetHDDAsync(productId, id, trackChanges);
        if (hddDb is null)
            throw new PSUNotFoundException(id);

        return hddDb;
    }

   
}