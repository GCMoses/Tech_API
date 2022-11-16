using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IGamingService;

namespace ComputerTechAPI_Services.GamingService;

public class GamingConsoleService : IGamingConsoleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public GamingConsoleService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
