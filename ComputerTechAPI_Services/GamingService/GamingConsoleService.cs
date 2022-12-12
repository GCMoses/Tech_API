using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using AutoMapper;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;

namespace ComputerTechAPI_Services.GamingService;

public class GamingConsoleService : IGamingConsoleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGamingConsoleLinks _gamingConsoleLinks;

    public GamingConsoleService(IRepositoryManager repository, ILogsManager logger, IMapper mapper, 
                                IGamingConsoleLinks gamingConsoleLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _gamingConsoleLinks = gamingConsoleLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetGamingConsolesAsync(Guid productId, GamingConsoleLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gamingConsoleParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var gamingConsolesWithMetaData = await _repository.GamingConsole
        .GetGamingConsolesAsync(productId, linkParameters.gamingConsoleParams, trackChanges);

        var gamingConsolesDTO = _mapper.Map<IEnumerable<GamingConsoleDTO>>
            (gamingConsolesWithMetaData);
        var links = _gamingConsoleLinks.TryGenerateLinks(gamingConsolesDTO,
        linkParameters.gamingConsoleParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gamingConsolesWithMetaData.MetaData);
    }


    public async Task<GamingConsoleDTO> GetGamingConsoleAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingConsoleDb = await GetGamingConsoleForProductAndCheckIfItExists(productId, id, trackChanges);

        var gamingConsole = _mapper.Map<GamingConsoleDTO>(gamingConsoleDb);
        return gamingConsole;
    }

    public async Task<GamingConsoleDTO> CreateGamingConsoleForProductAsync(Guid productId,
        GamingConsoleCreateDTO gamingConsoleCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingConsoleEntity = _mapper.Map<GamingConsole>(gamingConsoleCreate);

        _repository.GamingConsole.CreateGamingConsoleForProduct(productId, gamingConsoleEntity);
        await _repository.SaveAsync();

        var gamingConsoleToReturn = _mapper.Map<GamingConsoleDTO>(gamingConsoleEntity);

        return gamingConsoleToReturn;
    }

    public async Task DeleteGamingConsoleForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingConsoleDb = await GetGamingConsoleForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GamingConsole.DeleteGamingConsole(gamingConsoleDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGamingConsoleForProductAsync(Guid productId, Guid id, GamingConsoleUpdateDTO gamingConsoleUpdate,
                                                   bool productTrackChanges, bool gamingConsoleTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingConsoleDb = await GetGamingConsoleForProductAndCheckIfItExists(productId, id, gamingConsoleTrackChanges);

        _mapper.Map(gamingConsoleUpdate, gamingConsoleDb);
        await _repository.SaveAsync();
    }


    public async Task<(GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole gamingConsoleEntity)> GetGamingConsoleForPatchAsync
           (Guid productId, Guid id, bool productTrackChanges, bool gamingConsoleTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingConsoleDb = await GetGamingConsoleForProductAndCheckIfItExists(productId, id, gamingConsoleTrackChanges);

        var gamingConsoleToPatch = _mapper.Map<GamingConsoleUpdateDTO>(gamingConsoleDb);

        return (gamingConsoleToPatch: gamingConsoleToPatch, gamingConsoleEntity: gamingConsoleDb);
    }

    public async Task SaveChangesForPatchAsync(GamingConsoleUpdateDTO gamingConsoleToPatch, GamingConsole gamingConsoleEntity)
    {
        _mapper.Map(gamingConsoleToPatch, gamingConsoleEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GamingConsole> GetGamingConsoleForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gamingConsoleDb = await _repository.GamingConsole.GetGamingConsoleAsync(productId, id, trackChanges);
        if (gamingConsoleDb is null)
            throw new GamingConsoleNotFoundException(id);

        return gamingConsoleDb;
    }
}
