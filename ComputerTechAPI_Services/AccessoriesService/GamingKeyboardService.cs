using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingKeyboardService : IGamingKeyboardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGamingKeyboardLinks _gamingKeyboardLinks;
    public GamingKeyboardService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IGamingKeyboardLinks gamingKeyboardLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _gamingKeyboardLinks = gamingKeyboardLinks;
    }


    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetGamingKeyboardsAsync(Guid productId, GamingKeyboardLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gamingKeyboardParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var gamingKeyboardsWithMetaData = await _repository.GamingKeyboard
        .GetGamingKeyboardsAsync(productId, linkParameters.gamingKeyboardParams, trackChanges);

        var gamingKeyboardsDTO = _mapper.Map<IEnumerable<GamingKeyboardDTO>>
            (gamingKeyboardsWithMetaData);
        var links = _gamingKeyboardLinks.TryGenerateLinks(gamingKeyboardsDTO,
        linkParameters.gamingKeyboardParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gamingKeyboardsWithMetaData.MetaData);
    }



    public async Task<GamingKeyboardDTO> GetGamingKeyboardAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingKeyboardDb = await GetGamingKeyboardForProductAndCheckIfItExists(productId, id, trackChanges);

        var gamingKeyboard = _mapper.Map<GamingKeyboardDTO>(gamingKeyboardDb);
        return gamingKeyboard;
    }

    public async Task<GamingKeyboardDTO> CreateGamingKeyboardForProductAsync(Guid productId,
        GamingKeyboardCreateDTO gamingKeyboardCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingKeyboardEntity = _mapper.Map<GamingKeyboard>(gamingKeyboardCreate);

        _repository.GamingKeyboard.CreateGamingKeyboardForProduct(productId, gamingKeyboardEntity);
        await _repository.SaveAsync();

        var gamingKeyboardToReturn = _mapper.Map<GamingKeyboardDTO>(gamingKeyboardEntity);

        return gamingKeyboardToReturn;
    }

    public async Task DeleteGamingKeyboardForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingKeyboardDb = await GetGamingKeyboardForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GamingKeyboard.DeleteGamingKeyboard(gamingKeyboardDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGamingKeyboardForProductAsync(Guid productId, Guid id, GamingKeyboardUpdateDTO 
        gamingKeyboardUpdate, bool productTrackChanges, bool gamingKeyboardTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingKeyboardDb = await GetGamingKeyboardForProductAndCheckIfItExists(productId, id, gamingKeyboardTrackChanges);

        _mapper.Map(gamingKeyboardUpdate, gamingKeyboardDb);
        await _repository.SaveAsync();
    }

    public async Task<(GamingKeyboardUpdateDTO gamingKeyboardToPatch, GamingKeyboard gamingKeyboardEntity)> GetGamingKeyboardForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool gamingKeyboardTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingKeyboardDb = await GetGamingKeyboardForProductAndCheckIfItExists(productId, id, gamingKeyboardTrackChanges);

        var gamingKeyboardToPatch = _mapper.Map<GamingKeyboardUpdateDTO>(gamingKeyboardDb);

        return (gamingKeyboardToPatch: gamingKeyboardToPatch, gamingKeyboardEntity: gamingKeyboardDb);
    }

    public async Task SaveChangesForPatchAsync(GamingKeyboardUpdateDTO gamingKeyboardToPatch, GamingKeyboard gamingKeyboardEntity)
    {
        _mapper.Map(gamingKeyboardToPatch, gamingKeyboardEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GamingKeyboard> GetGamingKeyboardForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gamingKeyboardDb = await _repository.GamingKeyboard.GetGamingKeyboardAsync(productId, id, trackChanges);
        if (gamingKeyboardDb is null)
            throw new GamingKeyboardNotFoundException(id);

        return gamingKeyboardDb;
    }
  
}