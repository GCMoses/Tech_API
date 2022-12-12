using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.PCComponentService;

public class CPUService : ICPUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly ICPULinks _cpuLinks;
    public CPUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, ICPULinks cpuLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _cpuLinks = cpuLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetCPUsAsync(Guid productId, CPULinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.cpuParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var cpusWithMetaData = await _repository.CPU
        .GetCPUsAsync(productId, linkParameters.cpuParams, trackChanges);

        var cpusDTO = _mapper.Map<IEnumerable<CPUDTO>>
            (cpusWithMetaData);
        var links = _cpuLinks.TryGenerateLinks(cpusDTO,
        linkParameters.cpuParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: cpusWithMetaData.MetaData);
    }

    public async Task<CPUDTO> GetCPUAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var cpuDb = await GetCPUForProductAndCheckIfItExists(productId, id, trackChanges);

        var cpuDTO = _mapper.Map<CPUDTO>(cpuDb);
        return cpuDTO;
    }


    public async Task<CPUDTO> CreateCPUForProductAsync(Guid productId,
        CPUCreateDTO cpuCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var cpuEntity = _mapper.Map<CPU>(cpuCreate);

        _repository.CPU.CreateCPUForProduct(productId, cpuEntity);
        await _repository.SaveAsync();

        var cpuToReturn = _mapper.Map<CPUDTO>(cpuEntity);

        return cpuToReturn;
    }

    public async Task DeleteCPUForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var cpuDb = await GetCPUForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.CPU.DeleteCPU(cpuDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateCPUForProductAsync(Guid productId, Guid id, CPUUpdateDTO cpuUpdate,
                                               bool productTrackChanges, bool cpuTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var cpuDb = await GetCPUForProductAndCheckIfItExists(productId, id, cpuTrackChanges);

        _mapper.Map(cpuUpdate, cpuDb);
        await _repository.SaveAsync();
    }

    public async Task<(CPUUpdateDTO cpuToPatch, CPU cpuEntity)> GetCPUForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool cpuTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var cpuDb = await GetCPUForProductAndCheckIfItExists(productId, id, cpuTrackChanges);

        var cpuToPatch = _mapper.Map<CPUUpdateDTO>(cpuDb);

        return (cpuToPatch: cpuToPatch, cpuEntity: cpuDb);
    }

    public async Task SaveChangesForPatchAsync(CPUUpdateDTO cpuToPatch, CPU cpuEntity)
    {
        _mapper.Map(cpuToPatch, cpuEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<CPU> GetCPUForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var cpuDb = await _repository.CPU.GetCPUAsync(productId, id, trackChanges);
        if (cpuDb is null)
            throw new CPUNotFoundException(id);

        return cpuDb;
    }
}
