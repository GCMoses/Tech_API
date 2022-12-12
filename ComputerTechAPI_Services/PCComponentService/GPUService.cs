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

public class GPUService : IGPUService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly IGPULinks _gpuLinks;
    public GPUService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, IGPULinks gpuLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _gpuLinks = gpuLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetGPUsAsync(Guid productId, GPULinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.gpuParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var gpusWithMetaData = await _repository.GPU
        .GetGPUsAsync(productId, linkParameters.gpuParams, trackChanges);

        var gpusDTO = _mapper.Map<IEnumerable<GPUDTO>>
            (gpusWithMetaData);
        var links = _gpuLinks.TryGenerateLinks(gpusDTO,
        linkParameters.gpuParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: gpusWithMetaData.MetaData);
    }

    public async Task<GPUDTO> GetGPUAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gpuDb = await GetGPUForProductAndCheckIfItExists(productId, id, trackChanges);

        var gpuDTO = _mapper.Map<GPUDTO>(gpuDb);
        return gpuDTO;
    }


    public async Task<GPUDTO> CreateGPUForProductAsync(Guid productId,
        GPUCreateDTO gpuCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gpuEntity = _mapper.Map<GPU>(gpuCreate);

        _repository.GPU.CreateGPUForProduct(productId, gpuEntity);
        await _repository.SaveAsync();

        var gpuToReturn = _mapper.Map<GPUDTO>(gpuEntity);

        return gpuToReturn;
    }

    public async Task DeleteGPUForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var gpuDb = await GetGPUForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.GPU.DeleteGPU(gpuDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateGPUForProductAsync(Guid productId, Guid id, GPUUpdateDTO gpuUpdate,
                                               bool productTrackChanges, bool gpuTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gpuDb = await GetGPUForProductAndCheckIfItExists(productId, id, gpuTrackChanges);

        _mapper.Map(gpuUpdate, gpuDb);
        await _repository.SaveAsync();
    }

    public async Task<(GPUUpdateDTO gpuToPatch, GPU gpuEntity)> GetGPUForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool gpuTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var gpuDb = await GetGPUForProductAndCheckIfItExists(productId, id, gpuTrackChanges);

        var gpuToPatch = _mapper.Map<GPUUpdateDTO>(gpuDb);

        return (gpuToPatch: gpuToPatch, gpuEntity: gpuDb);
    }

    public async Task SaveChangesForPatchAsync(GPUUpdateDTO gpuToPatch, GPU gpuEntity)
    {
        _mapper.Map(gpuToPatch, gpuEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<GPU> GetGPUForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var gpuDb = await _repository.GPU.GetGPUAsync(productId, id, trackChanges);
        if (gpuDb is null)
            throw new GPUNotFoundException(id);

        return gpuDb;
    }
}
