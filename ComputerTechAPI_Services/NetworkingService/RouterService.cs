using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.INetworkingService;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using AutoMapper;
using ComputerTechAPI_Entities.ErrorExceptions.NetworkingErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Contracts.ILinks.INetworkingLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.NetworkingLinkParams;


namespace ComputerTechAPI_Services.NetworkingService;

public class RouterService : IRouterService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IRouterLinks _routerLinks;
    public RouterService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IRouterLinks routerLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _routerLinks = routerLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetRoutersAsync(Guid productId, RouterLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.routerParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var routersWithMetaData = await _repository.Router
        .GetRoutersAsync(productId, linkParameters.routerParams, trackChanges);

        var routersDTO = _mapper.Map<IEnumerable<RouterDTO>>
            (routersWithMetaData);
        var links = _routerLinks.TryGenerateLinks(routersDTO,
        linkParameters.routerParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: routersWithMetaData.MetaData);
    }



    public async Task<RouterDTO> GetRouterAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var routerDb = await GetRouterForProductAndCheckIfItExists(productId, id, trackChanges);

        var router = _mapper.Map<RouterDTO>(routerDb);
        return router;
    }

    public async Task<RouterDTO> CreateRouterForProductAsync(Guid productId,
        RouterCreateDTO routerCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var routerEntity = _mapper.Map<Router>(routerCreate);

        _repository.Router.CreateRouterForProduct(productId, routerEntity);
        await _repository.SaveAsync();

        var routerToReturn = _mapper.Map<RouterDTO>(routerEntity);

        return routerToReturn;
    }

    public async Task DeleteRouterForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var routerDb = await GetRouterForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.Router.DeleteRouter(routerDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateRouterForProductAsync(Guid productId, Guid id, RouterUpdateDTO routerUpdate,
                            bool productTrackChanges, bool routerTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var routerDb = await GetRouterForProductAndCheckIfItExists(productId, id, routerTrackChanges);

        _mapper.Map(routerUpdate, routerDb);
        await _repository.SaveAsync();
    }

    public async Task<(RouterUpdateDTO routerToPatch, Router routerEntity)> GetRouterForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool routerTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var routerDb = await GetRouterForProductAndCheckIfItExists(productId, id, routerTrackChanges);

        var routerToPatch = _mapper.Map<RouterUpdateDTO>(routerDb);

        return (routerToPatch: routerToPatch, routerEntity: routerDb);
    }

    public async Task SaveChangesForPatchAsync(RouterUpdateDTO routerToPatch, Router routerEntity)
    {
        _mapper.Map(routerToPatch, routerEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<Router> GetRouterForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var routerDb = await _repository.Router.GetRouterAsync(productId, id, trackChanges);
        if (routerDb is null)
            throw new RouterNotFoundException(id);

        return routerDb;
    }
    
}
