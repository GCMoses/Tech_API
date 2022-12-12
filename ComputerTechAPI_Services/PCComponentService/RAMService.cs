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

public class RAMService : IRAMService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IRAMLinks _ramLinks;
    public RAMService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IRAMLinks ramLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _ramLinks = ramLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetRAMsAsync(Guid productId, RAMLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.ramParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var ramsWithMetaData = await _repository.RAM
        .GetRAMsAsync(productId, linkParameters.ramParams, trackChanges);

        var ramsDTO = _mapper.Map<IEnumerable<RAMDTO>>
            (ramsWithMetaData);
        var links = _ramLinks.TryGenerateLinks(ramsDTO,
        linkParameters.ramParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: ramsWithMetaData.MetaData);
    }


    public async Task<RAMDTO> GetRAMAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var ramDb = await GetRAMForProductAndCheckIfItExists(productId, id, trackChanges);

        var ram = _mapper.Map<RAMDTO>(ramDb);
        var ramDTO = _mapper.Map<RAMDTO>(ramDb);
        return ramDTO;
    }

    public async Task<RAMDTO> CreateRAMForProductAsync(Guid productId,
        RAMCreateDTO ramCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var ramEntity = _mapper.Map<RAM>(ramCreate);

        _repository.RAM.CreateRAMForProduct(productId, ramEntity);
        await _repository.SaveAsync();

        var ramToReturn = _mapper.Map<RAMDTO>(ramEntity);

        return ramToReturn;
    }

    public async Task DeleteRAMForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var ramDb = await GetRAMForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.RAM.DeleteRAM(ramDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateRAMForProductAsync(Guid productId, Guid id, RAMUpdateDTO ramUpdate,
                                               bool productTrackChanges, bool ramTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var ramDb = await GetRAMForProductAndCheckIfItExists(productId, id, ramTrackChanges);

        _mapper.Map(ramUpdate, ramDb);
        await _repository.SaveAsync();
    }

    public async Task<(RAMUpdateDTO ramToPatch, RAM ramEntity)> GetRAMForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool ramTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var ramDb = await GetRAMForProductAndCheckIfItExists(productId, id, ramTrackChanges);

        var ramToPatch = _mapper.Map<RAMUpdateDTO>(ramDb);

        return (ramToPatch: ramToPatch, ramEntity: ramDb);
    }

    public async Task SaveChangesForPatchAsync(RAMUpdateDTO ramToPatch, RAM ramEntity)
    {
        _mapper.Map(ramToPatch, ramEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<RAM> GetRAMForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var ramDb = await _repository.RAM.GetRAMAsync(productId, id, trackChanges);
        if (ramDb is null)
            throw new RAMNotFoundException(id);

        return ramDb;
    }
}