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

public class MotherboardService : IMotherboardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IMotherboardLinks _motherboardLinks;
    public MotherboardService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IMotherboardLinks motherboardLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _motherboardLinks = motherboardLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetMotherboardsAsync(Guid productId, MotherboardLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.motherboardParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var motherboardsWithMetaData = await _repository.Motherboard
        .GetMotherboardsAsync(productId, linkParameters.motherboardParams, trackChanges);

        var motherboardsDTO = _mapper.Map<IEnumerable<MotherboardDTO>>
            (motherboardsWithMetaData);
        var links = _motherboardLinks.TryGenerateLinks(motherboardsDTO,
        linkParameters.motherboardParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: motherboardsWithMetaData.MetaData);
    }

    public async Task<MotherboardDTO> GetMotherboardAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var motherboardDb = await GetMotherboardForProductAndCheckIfItExists(productId, id, trackChanges);

        var motherboardDTO = _mapper.Map<MotherboardDTO>(motherboardDb);
        return motherboardDTO;
    }


    public async Task<MotherboardDTO> CreateMotherboardForProductAsync(Guid productId,
        MotherboardCreateDTO motherboardCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var motherboardEntity = _mapper.Map<Motherboard>(motherboardCreate);

        _repository.Motherboard.CreateMotherboardForProduct(productId, motherboardEntity);
        await _repository.SaveAsync();

        var motherboardToReturn = _mapper.Map<MotherboardDTO>(motherboardEntity);

        return motherboardToReturn;
    }

    public async Task DeleteMotherboardForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var motherboardDb = await GetMotherboardForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.Motherboard.DeleteMotherboard(motherboardDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateMotherboardForProductAsync(Guid productId, Guid id, MotherboardUpdateDTO motherboardUpdate,
                                               bool productTrackChanges, bool motherboardTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var motherboardDb = await GetMotherboardForProductAndCheckIfItExists(productId, id, motherboardTrackChanges);

        _mapper.Map(motherboardUpdate, motherboardDb);
        await _repository.SaveAsync();
    }

    public async Task<(MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity)> GetMotherboardForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool motherboardTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var motherboardDb = await GetMotherboardForProductAndCheckIfItExists(productId, id, motherboardTrackChanges);

        var motherboardToPatch = _mapper.Map<MotherboardUpdateDTO>(motherboardDb);

        return (motherboardToPatch: motherboardToPatch, motherboardEntity: motherboardDb);
    }

    public async Task SaveChangesForPatchAsync(MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity)
    {
        _mapper.Map(motherboardToPatch, motherboardEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<Motherboard> GetMotherboardForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var motherboardDb = await _repository.Motherboard.GetMotherboardAsync(productId, id, trackChanges);
        if (motherboardDb is null)
            throw new MotherboardNotFoundException(id);

        return motherboardDb;
    }

    public Task<(MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity)> GetMotherboardForPatchAsync(Guid productId, Guid id, MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity)
    {
        throw new NotImplementedException();
    }
}