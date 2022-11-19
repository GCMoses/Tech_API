using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.PCService;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;

namespace ComputerTechAPI_Services.PCService;

public class DesktopService : IDesktopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public DesktopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<DesktopDTO> GetDesktops(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var desktopDb = _repository.Desktop.GetDesktops(productId, trackChanges);
        var desktopDTO = _mapper.Map<IEnumerable<DesktopDTO>>(desktopDb);
        return desktopDTO;
    }


    public DesktopDTO GetDesktop(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var desktopDb = _repository.Desktop.GetDesktop(productId, id, trackChanges);
        if (desktopDb is null)
            throw new DesktopNotFoundException(id);

        var desktop = _mapper.Map<DesktopDTO>(desktopDb);
        return desktop;
    }
}