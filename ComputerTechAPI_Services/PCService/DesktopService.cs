using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.PCService;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_Contracts.ILinks.INetworkingLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.NetworkingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Contracts.ILinks.IPCLinks;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;

namespace ComputerTechAPI_Services.PCService;

public class DesktopService : IDesktopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IDesktopLinks _desktopLinks;
    public DesktopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IDesktopLinks desktopLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _desktopLinks = desktopLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetDesktopsAsync(Guid productId, DesktopLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.desktopParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var desktopsWithMetaData = await _repository.Desktop
        .GetDesktopsAsync(productId, linkParameters.desktopParams, trackChanges);

        var desktopsDTO = _mapper.Map<IEnumerable<DesktopDTO>>
            (desktopsWithMetaData);
        var links = _desktopLinks.TryGenerateLinks(desktopsDTO,
        linkParameters.desktopParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: desktopsWithMetaData.MetaData);
    }

    public async Task<DesktopDTO> GetDesktopAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var desktopDb = await GetDesktopForProductAndCheckIfItExists(productId, id, trackChanges);

        var desktopDTO = _mapper.Map<DesktopDTO>(desktopDb);
        return desktopDTO;
    }

    public async Task<DesktopDTO> CreateDesktopForProductAsync(Guid productId,
        DesktopCreateDTO desktopCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var desktopEntity = _mapper.Map<Desktop>(desktopCreate);

        _repository.Desktop.CreateDesktopForProduct(productId, desktopEntity);
        await _repository.SaveAsync();

        var desktopToReturn = _mapper.Map<DesktopDTO>(desktopEntity);

        return desktopToReturn;
    }

    public async Task DeleteDesktopForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var desktopDb = await GetDesktopForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.Desktop.DeleteDesktop(desktopDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateDesktopForProductAsync(Guid productId, Guid id, DesktopUpdateDTO
        desktopUpdate, bool productTrackChanges, bool desktopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var desktopDb = await GetDesktopForProductAndCheckIfItExists(productId, id, desktopTrackChanges);

        _mapper.Map(desktopUpdate, desktopDb);
        await _repository.SaveAsync();
    }

    public async Task<(DesktopUpdateDTO desktopToPatch, Desktop desktopEntity)> GetDesktopForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool desktopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var desktopDb = await GetDesktopForProductAndCheckIfItExists(productId, id, desktopTrackChanges);

        var desktopToPatch = _mapper.Map<DesktopUpdateDTO>(desktopDb);

        return (desktopToPatch: desktopToPatch, desktopEntity: desktopDb);
    }

    public async Task SaveChangesForPatchAsync(DesktopUpdateDTO desktopToPatch, Desktop desktopEntity)
    {
        _mapper.Map(desktopToPatch, desktopEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<Desktop> GetDesktopForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var desktopDb = await _repository.Desktop.GetDesktopAsync(productId, id, trackChanges);
        if (desktopDb is null)
            throw new DesktopNotFoundException(id);

        return desktopDb;
    }
}
