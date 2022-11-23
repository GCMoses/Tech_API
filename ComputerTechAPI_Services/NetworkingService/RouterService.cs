using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.INetworkingService;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using AutoMapper;
using ComputerTechAPI_Entities.ErrorExceptions.NetworkingErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;

namespace ComputerTechAPI_Services.NetworkingService;

public class RouterService : IRouterService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public RouterService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<RouterDTO> GetRouters(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var routerDb = _repository.Router.GetRouters(productId, trackChanges);
        var routerDTO = _mapper.Map<IEnumerable<RouterDTO>>(routerDb);
        return routerDTO;
    }


    public RouterDTO GetRouter(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var routerDb = _repository.Router.GetRouter(productId, id, trackChanges);
        if (routerDb is null)
            throw new RouterNotFoundException(id);

        var router = _mapper.Map<RouterDTO>(routerDb);
        return router;
    }

   

    public RouterDTO CreateRouterForProduct(Guid productId, RouterCreateDTO routerCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var routerEntity = _mapper.Map<Router>(routerCreate);
        _repository.Router.CreateRouterForProduct(productId, routerEntity);
        _repository.Save();
        var routerToReturn = _mapper.Map<RouterDTO>(routerEntity);
        return routerToReturn;
    }


    public void DeleteRouterForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var routerForProduct = _repository.Router.GetRouter(productId, id, trackChanges);
        if (routerForProduct is null)
            throw new RouterNotFoundException(id);
        _repository.Router.DeleteRouter(routerForProduct);
        _repository.Save();
    }


    public void UpdateRouterForProduct(Guid productId, Guid id, RouterUpdateDTO routerUpdate,
                                       bool productTrackChanges, bool routerTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var routerEntity = _repository.Router.GetRouter(productId, id,
        routerTrackChanges);
        if (routerEntity is null)
            throw new RouterNotFoundException(id);
        _mapper.Map(routerUpdate, routerEntity);
        _repository.Save();
    }
}
