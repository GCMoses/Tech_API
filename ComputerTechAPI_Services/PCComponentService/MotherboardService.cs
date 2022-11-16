using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class MotherboardService : IMotherboardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public MotherboardService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
