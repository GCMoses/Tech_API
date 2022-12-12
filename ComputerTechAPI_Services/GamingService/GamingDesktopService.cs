using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_TechService.Contracts.IGamingService;

namespace ComputerTechAPI_Services.GamingService;

public class GamingDesktopService : IGamingDesktopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGamingDesktopLinks _gamingDesktopLinks;
    public GamingDesktopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IGamingDesktopLinks gamingDesktopLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _gamingDesktopLinks = gamingDesktopLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetGamingDesktopsAsync(Guid productId, GamingDesktopLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gamingDesktopParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var gamingDesktopsWithMetaData = await _repository.GamingDesktop
        .GetGamingDesktopsAsync(productId, linkParameters.gamingDesktopParams, trackChanges);

        var gamingDesktopsDTO = _mapper.Map<IEnumerable<GamingDesktopDTO>>
            (gamingDesktopsWithMetaData);
        var links = _gamingDesktopLinks.TryGenerateLinks(gamingDesktopsDTO,
        linkParameters.gamingDesktopParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gamingDesktopsWithMetaData.MetaData);
    }



    public async Task<GamingDesktopDTO> GetGamingDesktopAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingDesktopDb = await GetGamingDesktopForProductAndCheckIfItExists(productId, id, trackChanges);

        var gamingDesktop = _mapper.Map<GamingDesktopDTO>(gamingDesktopDb);
        return gamingDesktop;
    }

    public async Task<GamingDesktopDTO> CreateGamingDesktopForProductAsync(Guid productId,
        GamingDesktopCreateDTO gamingDesktopCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingDesktopEntity = _mapper.Map<GamingDesktop>(gamingDesktopCreate);

        _repository.GamingDesktop.CreateGamingDesktopForProduct(productId, gamingDesktopEntity);
        await _repository.SaveAsync();

        var gamingDesktopToReturn = _mapper.Map<GamingDesktopDTO>(gamingDesktopEntity);

        return gamingDesktopToReturn;
    }

    public async Task DeleteGamingDesktopForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingDesktopDb = await GetGamingDesktopForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GamingDesktop.DeleteGamingDesktop(gamingDesktopDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGamingDesktopForProductAsync(Guid productId, Guid id, GamingDesktopUpdateDTO
        gamingDesktopUpdate, bool productTrackChanges, bool gamingDesktopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingDesktopDb = await GetGamingDesktopForProductAndCheckIfItExists(productId, id, gamingDesktopTrackChanges);

        _mapper.Map(gamingDesktopUpdate, gamingDesktopDb);
        await _repository.SaveAsync();
    }

    public async Task<(GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop gamingDesktopEntity)> GetGamingDesktopForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool gamingDesktopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingDesktopDb = await GetGamingDesktopForProductAndCheckIfItExists(productId, id, gamingDesktopTrackChanges);

        var gamingDesktopToPatch = _mapper.Map<GamingDesktopUpdateDTO>(gamingDesktopDb);

        return (gamingDesktopToPatch: gamingDesktopToPatch, gamingDesktopEntity: gamingDesktopDb);
    }

    public async Task SaveChangesForPatchAsync(GamingDesktopUpdateDTO gamingDesktopToPatch, GamingDesktop gamingDesktopEntity)
    {
        _mapper.Map(gamingDesktopToPatch, gamingDesktopEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GamingDesktop> GetGamingDesktopForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gamingDesktopDb = await _repository.GamingDesktop.GetGamingDesktopAsync(productId, id, trackChanges);
        if (gamingDesktopDb is null)
            throw new GamingDesktopNotFoundException(id);

        return gamingDesktopDb;
    }
}
