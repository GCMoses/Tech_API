using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingMouseService : IGamingMouseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public GamingMouseService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}