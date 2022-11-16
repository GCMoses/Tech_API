using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class SSDService : ISSDService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public SSDService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
