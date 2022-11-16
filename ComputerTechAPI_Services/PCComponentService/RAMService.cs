using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class RAMService : IRAMService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public RAMService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
