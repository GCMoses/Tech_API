using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.PCService;

namespace ComputerTechAPI_Services.PCService;

public class DesktopService : IDesktopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public DesktopService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
