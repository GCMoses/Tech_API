using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.IAccessoriesService;

namespace ComputerTechAPI_Services.AccessoriesService;

public class GamingHeadphonesAndHeadsetService : IGamingHeadphonesAndHeadsetService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public GamingHeadphonesAndHeadsetService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
