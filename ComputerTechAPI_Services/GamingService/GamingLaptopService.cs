using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IGamingService;
using AutoMapper;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;

namespace ComputerTechAPI_Services.GamingService;

public class GamingLaptopService : IGamingLaptopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGamingLaptopLinks _gamingLaptopLinks;
    public GamingLaptopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IGamingLaptopLinks gamingLaptopLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _gamingLaptopLinks = gamingLaptopLinks;
    }


    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetGamingLaptopsAsync(Guid productId, GamingLaptopLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gamingLaptopParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var gamingLaptopsWithMetaData = await _repository.GamingLaptop
        .GetGamingLaptopsAsync(productId, linkParameters.gamingLaptopParams, trackChanges);

        var gamingLaptopsDTO = _mapper.Map<IEnumerable<GamingLaptopDTO>>
            (gamingLaptopsWithMetaData);
        var links = _gamingLaptopLinks.TryGenerateLinks(gamingLaptopsDTO,
        linkParameters.gamingLaptopParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gamingLaptopsWithMetaData.MetaData);
    }


    public async Task<GamingLaptopDTO> GetGamingLaptopAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingLaptopDb = await GetGamingLaptopForProductAndCheckIfItExists(productId, id, trackChanges);

        var gamingLaptop = _mapper.Map<GamingLaptopDTO>(gamingLaptopDb);
        return gamingLaptop;
    }

    public async Task<GamingLaptopDTO> CreateGamingLaptopForProductAsync(Guid productId,
        GamingLaptopCreateDTO gamingLaptopCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingLaptopEntity = _mapper.Map<GamingLaptop>(gamingLaptopCreate);

        _repository.GamingLaptop.CreateGamingLaptopForProduct(productId, gamingLaptopEntity);
        await _repository.SaveAsync();

        var gamingLaptopToReturn = _mapper.Map<GamingLaptopDTO>(gamingLaptopEntity);

        return gamingLaptopToReturn;
    }

    public async Task DeleteGamingLaptopForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingLaptopDb = await GetGamingLaptopForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GamingLaptop.DeleteGamingLaptop(gamingLaptopDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGamingLaptopForProductAsync(Guid productId, Guid id, GamingLaptopUpdateDTO
        gamingLaptopUpdate, bool productTrackChanges, bool gamingLaptopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingLaptopDb = await GetGamingLaptopForProductAndCheckIfItExists(productId, id, gamingLaptopTrackChanges);

        _mapper.Map(gamingLaptopUpdate, gamingLaptopDb);
        await _repository.SaveAsync();
    }

    public async Task<(GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop gamingLaptopEntity)> GetGamingLaptopForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool gamingLaptopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingLaptopDb = await GetGamingLaptopForProductAndCheckIfItExists(productId, id, gamingLaptopTrackChanges);

        var gamingLaptopToPatch = _mapper.Map<GamingLaptopUpdateDTO>(gamingLaptopDb);

        return (gamingLaptopToPatch: gamingLaptopToPatch, gamingLaptopEntity: gamingLaptopDb);
    }

    public async Task SaveChangesForPatchAsync(GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop gamingLaptopEntity)
    {
        _mapper.Map(gamingLaptopToPatch, gamingLaptopEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GamingLaptop> GetGamingLaptopForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gamingLaptopDb = await _repository.GamingLaptop.GetGamingLaptopAsync(productId, id, trackChanges);
        if (gamingLaptopDb is null)
            throw new GamingLaptopNotFoundException(id);

        return gamingLaptopDb;
    }
}