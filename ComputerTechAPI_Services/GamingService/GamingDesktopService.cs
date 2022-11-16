using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IGamingService;

namespace ComputerTechAPI_Services.GamingService;

public class GamingDesktopService : IGamingDesktopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public GamingDesktopService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
