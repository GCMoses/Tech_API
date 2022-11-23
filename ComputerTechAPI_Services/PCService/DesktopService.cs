using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.PCService;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;

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


    public DesktopDTO CreateDesktopForProduct(Guid productId, DesktopCreateDTO desktop, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var desktopEntity = _mapper.Map<Desktop>(desktop);
        _repository.Desktop.CreateDesktopForProduct(productId, desktopEntity);
        _repository.Save();
        var desktopToReturn = _mapper.Map<DesktopDTO>(desktopEntity);
        return desktopToReturn;
    }


    public void DeleteDesktopForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var desktopForProduct = _repository.Desktop.GetDesktop(productId, id, trackChanges);
        if (desktopForProduct is null)
            throw new DesktopNotFoundException(id);
        _repository.Desktop.DeleteDesktop(desktopForProduct);
        _repository.Save();
    }


    public void UpdateDesktopForProduct(Guid productId, Guid id, DesktopUpdateDTO desktopUpdate,
                                   bool productTrackChanges, bool desktopTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var desktopEntity = _repository.Desktop.GetDesktop(productId, id,
        desktopTrackChanges);
        if (desktopEntity is null)
            throw new DesktopNotFoundException(id);
        _mapper.Map(desktopUpdate, desktopEntity);
        _repository.Save();
    }
}
