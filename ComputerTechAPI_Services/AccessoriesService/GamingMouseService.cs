using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;
using AutoMapper;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingMouseService : IGamingMouseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGamingMouseLinks _gamingMouseLinks;
    public GamingMouseService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IGamingMouseLinks gamingMouseLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _gamingMouseLinks = gamingMouseLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetGamingMousesAsync(Guid productId, GamingMouseLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gamingMouseParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var gamingMousesWithMetaData = await _repository.GamingMouse
        .GetGamingMousesAsync(productId, linkParameters.gamingMouseParams, trackChanges);

        var gamingMousesDTO = _mapper.Map<IEnumerable<GamingMouseDTO>>
            (gamingMousesWithMetaData);
        var links = _gamingMouseLinks.TryGenerateLinks(gamingMousesDTO,
        linkParameters.gamingMouseParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gamingMousesWithMetaData.MetaData);
    }


    public async Task<GamingMouseDTO> GetGamingMouseAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingMouseDb = await GetGamingMouseForProductAndCheckIfItExists(productId, id, trackChanges);

        var gamingMouse = _mapper.Map<GamingMouseDTO>(gamingMouseDb);
        return gamingMouse;
    }

    public async Task<GamingMouseDTO> CreateGamingMouseForProductAsync(Guid productId,
        GamingMouseCreateDTO gamingMouseCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingMouseEntity = _mapper.Map<GamingMouse>(gamingMouseCreate);

        _repository.GamingMouse.CreateGamingMouseForProduct(productId, gamingMouseEntity);
        await _repository.SaveAsync();

        var gamingMouseToReturn = _mapper.Map<GamingMouseDTO>(gamingMouseEntity);

        return gamingMouseToReturn;
    }

    public async Task DeleteGamingMouseForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingMouseDb = await GetGamingMouseForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GamingMouse.DeleteGamingMouse(gamingMouseDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGamingMouseForProductAsync(Guid productId, Guid id, GamingMouseUpdateDTO
        gamingMouseUpdate, bool productTrackChanges, bool gamingMouseTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingMouseDb = await GetGamingMouseForProductAndCheckIfItExists(productId, id, gamingMouseTrackChanges);

        _mapper.Map(gamingMouseUpdate, gamingMouseDb);
        await _repository.SaveAsync();
    }

    public async Task<(GamingMouseUpdateDTO gamingMouseToPatch, GamingMouse gamingMouseEntity)> GetGamingMouseForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool gamingMouseTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingMouseDb = await GetGamingMouseForProductAndCheckIfItExists(productId, id, gamingMouseTrackChanges);

        var gamingMouseToPatch = _mapper.Map<GamingMouseUpdateDTO>(gamingMouseDb);

        return (gamingMouseToPatch: gamingMouseToPatch, gamingMouseEntity: gamingMouseDb);
    }

    public async Task SaveChangesForPatchAsync(GamingMouseUpdateDTO gamingMouseToPatch, GamingMouse gamingMouseEntity)
    {
        _mapper.Map(gamingMouseToPatch, gamingMouseEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GamingMouse> GetGamingMouseForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gamingMouseDb = await _repository.GamingMouse.GetGamingMouseAsync(productId, id, trackChanges);
        if (gamingMouseDb is null)
            throw new GamingMouseNotFoundException(id);

        return gamingMouseDb;
    }
}