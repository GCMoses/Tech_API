using ComputerTechAPI_Contracts;
using ComputerTechAPI_TechService.Contracts.PCService;

namespace ComputerTechAPI_Services.PCService;

public class LaptopService : ILaptopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    public LaptopService(IRepositoryManager repository, ILogsManager
    logger)
    {
        _repository = repository;
        _logger = logger;
    }
}