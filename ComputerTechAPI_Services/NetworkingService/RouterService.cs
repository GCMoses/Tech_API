using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.INetworkingService;

namespace ComputerTechAPI_Services.NetworkingService;

public class RouterService : IRouterService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public RouterService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
