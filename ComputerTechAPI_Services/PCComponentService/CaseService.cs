using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.PCComponentService;

public class CaseService : ICaseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly ICaseLinks _pcCaseLinks;
    public CaseService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, ICaseLinks pcCaseLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _pcCaseLinks = pcCaseLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
    GetCasesAsync(Guid productId, CaseLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.pcCaseParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var pcCasesWithMetaData = await _repository.Case
        .GetCasesAsync(productId, linkParameters.pcCaseParams, trackChanges);

        var pcCasesDTO = _mapper.Map<IEnumerable<CaseDTO>>
            (pcCasesWithMetaData);
        var links = _pcCaseLinks.TryGenerateLinks(pcCasesDTO,
        linkParameters.pcCaseParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: pcCasesWithMetaData.MetaData);
    }

    public async Task<CaseDTO> GetCaseAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var pcCaseDb = await GetCaseForProductAndCheckIfItExists(productId, id, trackChanges);

        var pcCaseDTO = _mapper.Map<CaseDTO>(pcCaseDb);
        return pcCaseDTO;
    }


    public async Task<CaseDTO> CreateCaseForProductAsync(Guid productId,
        CaseCreateDTO pcCaseCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var pcCaseEntity = _mapper.Map<Case>(pcCaseCreate);

        _repository.Case.CreateCaseForProduct(productId, pcCaseEntity);
        await _repository.SaveAsync();

        var pcCaseToReturn = _mapper.Map<CaseDTO>(pcCaseEntity);

        return pcCaseToReturn;
    }

    public async Task DeleteCaseForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var pcCaseDb = await GetCaseForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.Case.DeleteCase(pcCaseDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateCaseForProductAsync(Guid productId, Guid id, CaseUpdateDTO pcCaseUpdate,
                                               bool productTrackChanges, bool pcCaseTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var pcCaseDb = await GetCaseForProductAndCheckIfItExists(productId, id, pcCaseTrackChanges);

        _mapper.Map(pcCaseUpdate, pcCaseDb);
        await _repository.SaveAsync();
    }

    public async Task<(CaseUpdateDTO pcCaseToPatch, Case pcCaseEntity)> GetCaseForPatchAsync
                      (Guid productId, Guid id, bool productTrackChanges, bool pcCaseTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var pcCaseDb = await GetCaseForProductAndCheckIfItExists(productId, id, pcCaseTrackChanges);

        var pcCaseToPatch = _mapper.Map<CaseUpdateDTO>(pcCaseDb);

        return (pcCaseToPatch: pcCaseToPatch, pcCaseEntity: pcCaseDb);
    }

    public async Task SaveChangesForPatchAsync(CaseUpdateDTO pcCaseToPatch, Case pcCaseEntity)
    {
        _mapper.Map(pcCaseToPatch, pcCaseEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<Case> GetCaseForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var pcCaseDb = await _repository.Case.GetCaseAsync(productId, id, trackChanges);
        if (pcCaseDb is null)
            throw new CPUNotFoundException(id);

        return pcCaseDb; 
    }
}
