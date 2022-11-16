using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

namespace ComputerTechAPI_Services.SmartDeviceService;

public class DroneService : IDroneService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public DroneService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}