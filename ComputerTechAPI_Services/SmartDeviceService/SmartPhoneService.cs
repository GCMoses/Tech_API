using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.ISmartDeviceService;

namespace ComputerTechAPI_Services.PCSeSmartDeviceServicervice;

internal sealed class SmartPhoneService : ISmartPhoneService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public SmartPhoneService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
