using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;
using System.ComponentModel.Design;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingHeadphonesAndHeadsetService : IGamingHeadphonesAndHeadsetService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGamingHeadphonesAndHeadsetLinks _gamingHeadphonesAndHeadsetLinks;
    public GamingHeadphonesAndHeadsetService(IRepositoryManager repositoryManager, ILogsManager
    logger, IMapper mapper, IGamingHeadphonesAndHeadsetLinks gamingHeadphonesAndHeadsetLinks)
    {
        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;
        _gamingHeadphonesAndHeadsetLinks = gamingHeadphonesAndHeadsetLinks;
    }



    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetGamingHeadphonesAndHeadsetsAsync(Guid productId, GamingHeadphonesAndHeadsetLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gamingHeadphonesAndHeadsetParams.RatingRange)
            throw new RatingRangeBadRequestException(); 

        await CheckIfProductExists(productId, trackChanges);
        var gamingHeadphonesAndHeadsetsWithMetaData = await _repository.GamingHeadphonesAndHeadset
        .GetGamingHeadphonesAndHeadsetsAsync(productId, linkParameters.gamingHeadphonesAndHeadsetParams, trackChanges);

        var gamingHeadphonesAndHeadsetsDTO =_mapper.Map<IEnumerable<GamingHeadphonesAndHeadsetDTO>>
            (gamingHeadphonesAndHeadsetsWithMetaData);
        var links = _gamingHeadphonesAndHeadsetLinks.TryGenerateLinks(gamingHeadphonesAndHeadsetsDTO,
        linkParameters.gamingHeadphonesAndHeadsetParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gamingHeadphonesAndHeadsetsWithMetaData.MetaData);
    }



    public async Task<GamingHeadphonesAndHeadsetDTO> GetGamingHeadphonesAndHeadsetAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingHeadPhonesAndHeadsetDb = await GetGamingHeadphonesAndHeadsetForProductAndCheckIfItExists(productId, id, trackChanges);

        var gamingHeadPhonesAndHeadset = _mapper.Map<GamingHeadphonesAndHeadsetDTO>(gamingHeadPhonesAndHeadsetDb);
        return gamingHeadPhonesAndHeadset;
    }

    public async Task<GamingHeadphonesAndHeadsetDTO> CreateGamingHeadphonesAndHeadsetForProductAsync(Guid productId,
        GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadsetCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingHeadphonesAndHeadsetEntity = _mapper.Map<GamingHeadphonesAndHeadset>(gamingHeadphonesAndHeadsetCreate);

        _repository.GamingHeadphonesAndHeadset.CreateGamingHeadphonesAndHeadsetForProduct(productId, gamingHeadphonesAndHeadsetEntity);
        await _repository.SaveAsync();

        var gamingHeadphonesAndHeadsetToReturn = _mapper.Map<GamingHeadphonesAndHeadsetDTO>(gamingHeadphonesAndHeadsetEntity);

        return gamingHeadphonesAndHeadsetToReturn;
    }

    public async Task DeleteGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gamingHeadphonesAndHeadsetDb = await GetGamingHeadphonesAndHeadsetForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GamingHeadphonesAndHeadset.DeleteGamingHeadphonesAndHeadset(gamingHeadphonesAndHeadsetDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id,
        GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetUpdate,
        bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingHeadphonesAndHeadsetDb = await GetGamingHeadphonesAndHeadsetForProductAndCheckIfItExists(productId, id,
            gamingHeadphonesAndHeadsetTrackChanges);

        _mapper.Map(gamingHeadphonesAndHeadsetUpdate, gamingHeadphonesAndHeadsetDb);
        await _repository.SaveAsync();
    }

    public async Task<(GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetToPatch, GamingHeadphonesAndHeadset 
      gamingHeadphonesAndHeadsetEntity)> GetGamingHeadphonesAndHeadsetForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool gamingHeadphonesAndHeadsetTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gamingHeadphonesAndHeadsetDb = await GetGamingHeadphonesAndHeadsetForProductAndCheckIfItExists(productId, id, gamingHeadphonesAndHeadsetTrackChanges);

        var gamingHeadphonesAndHeadsetToPatch = _mapper.Map<GamingHeadphonesAndHeadsetUpdateDTO>(gamingHeadphonesAndHeadsetDb);

        return (gamingHeadphonesAndHeadsetToPatch: gamingHeadphonesAndHeadsetToPatch, gamingHeadphonesAndHeadsetEntity: gamingHeadphonesAndHeadsetDb);
    }

    public async Task SaveChangesForPatchAsync(GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetToPatch,
                                               GamingHeadphonesAndHeadset gamingHeadphonesAndHeadsetEntity)
    {
        _mapper.Map(gamingHeadphonesAndHeadsetToPatch, gamingHeadphonesAndHeadsetEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GamingHeadphonesAndHeadset> GetGamingHeadphonesAndHeadsetForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gamingHeadphonesAndHeadsetDb = await _repository.GamingHeadphonesAndHeadset.GetGamingHeadphonesAndHeadsetAsync(productId,
            id, trackChanges);
        if (gamingHeadphonesAndHeadsetDb is null)
            throw new GamingHeadphonesAndHeadsetNotFoundException(id);

        return gamingHeadphonesAndHeadsetDb;
    }

   
}
