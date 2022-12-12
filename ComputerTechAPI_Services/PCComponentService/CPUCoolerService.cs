using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.PCComponentService;

public class CPUCoolerService : ICPUCoolerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly ICPUCoolerLinks _cpuCoolerLinks;
    public CPUCoolerService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, ICPUCoolerLinks cpuCoolerLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _cpuCoolerLinks = cpuCoolerLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetCPUCoolersAsync(Guid productId, CPUCoolerLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.cpuCoolerParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var cpuCoolersWithMetaData = await _repository.CPUCooler
        .GetCPUCoolersAsync(productId, linkParameters.cpuCoolerParams, trackChanges);

        var cpuCoolersDTO = _mapper.Map<IEnumerable<CPUCoolerDTO>>
            (cpuCoolersWithMetaData);
        var links = _cpuCoolerLinks.TryGenerateLinks(cpuCoolersDTO,
        linkParameters.cpuCoolerParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: cpuCoolersWithMetaData.MetaData);
    }

    public async Task<CPUCoolerDTO> GetCPUCoolerAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var cpuCoolerDb = await GetCPUCoolerForProductAndCheckIfItExists(productId, id, trackChanges);

        var cpuCoolerDTO = _mapper.Map<CPUCoolerDTO>(cpuCoolerDb);
        return cpuCoolerDTO;
    }


    public async Task<CPUCoolerDTO> CreateCPUCoolerForProductAsync(Guid productId,
        CPUCoolerCreateDTO cpuCoolerCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var cpuCoolerEntity = _mapper.Map<CPUCooler>(cpuCoolerCreate);

        _repository.CPUCooler.CreateCPUCoolerForProduct(productId, cpuCoolerEntity);
        await _repository.SaveAsync();

        var cpuCoolerToReturn = _mapper.Map<CPUCoolerDTO>(cpuCoolerEntity);

        return cpuCoolerToReturn;
    }

    public async Task DeleteCPUCoolerForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var cpuCoolerDb = await GetCPUCoolerForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.CPUCooler.DeleteCPUCooler(cpuCoolerDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateCPUCoolerForProductAsync(Guid productId, Guid id, CPUCoolerUpdateDTO cpuCoolerUpdate,
                                               bool productTrackChanges, bool cpuCoolerTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var cpuCoolerDb = await GetCPUCoolerForProductAndCheckIfItExists(productId, id, cpuCoolerTrackChanges);

        _mapper.Map(cpuCoolerUpdate, cpuCoolerDb);
        await _repository.SaveAsync();
    }

    public async Task<(CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler cpuCoolerEntity)> GetCPUCoolerForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool cpuCoolerTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var cpuCoolerDb = await GetCPUCoolerForProductAndCheckIfItExists(productId, id, cpuCoolerTrackChanges);

        var cpuCoolerToPatch = _mapper.Map<CPUCoolerUpdateDTO>(cpuCoolerDb);

        return (cpuCoolerToPatch: cpuCoolerToPatch, cpuCoolerEntity: cpuCoolerDb);
    }

    public async Task SaveChangesForPatchAsync(CPUCoolerUpdateDTO cpuCoolerToPatch, CPUCooler cpuCoolerEntity)
    {
        _mapper.Map(cpuCoolerToPatch, cpuCoolerEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<CPUCooler> GetCPUCoolerForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var cpuCoolerDb = await _repository.CPUCooler.GetCPUCoolerAsync(productId, id, trackChanges);
        if (cpuCoolerDb is null)
            throw new CPUCoolerNotFoundException(id);

        return cpuCoolerDb;
    }
}