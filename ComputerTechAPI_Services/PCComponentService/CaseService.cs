using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions.NetworkingErrorExceptions;

namespace ComputerTechAPI_Services.PCComponentService;

public class CaseService : ICaseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public CaseService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CaseDTO> GetCases(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        //changed case to pcCase since case define pattern in C#
        var pcCaseDb = _repository.Case.GetCases(productId, trackChanges);
        var pcCaseDTO = _mapper.Map<IEnumerable<CaseDTO>>(pcCaseDb);
        return pcCaseDTO;
    }


    public CaseDTO GetCase(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var pcCaseDb = _repository.Case.GetCase(productId, id, trackChanges);
        if (pcCaseDb is null)
            throw new CaseNotFoundException(id);

        var pcCase = _mapper.Map<CaseDTO>(pcCaseDb);
        return pcCase;
    }


    public CaseDTO CreateCaseForProduct(Guid productId, CaseCreateDTO pcCaseCreate, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var pcCaseEntity = _mapper.Map<Case>(pcCaseCreate);
        _repository.Case.CreateCaseForProduct(productId, pcCaseEntity);
        _repository.Save();
        var pcCaseToReturn = _mapper.Map<CaseDTO>(pcCaseEntity);
        return pcCaseToReturn;
    }


    public void DeleteCaseForProduct(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var pcCaseForProduct = _repository.Case.GetCase(productId, id, trackChanges);
        if (pcCaseForProduct is null)
            throw new CaseNotFoundException(id);
        _repository.Case.DeleteCase(pcCaseForProduct);
        _repository.Save();
    }


    public void UpdateCaseForProduct(Guid productId, Guid id, CaseUpdateDTO pcCaseUpdate,
                                       bool productTrackChanges, bool pcCaseTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var pcCaseEntity = _repository.Case.GetCase(productId, id,
        pcCaseTrackChanges);
        if (pcCaseEntity is null)
            throw new CaseNotFoundException(id);
        _mapper.Map(pcCaseUpdate, pcCaseEntity);
        _repository.Save();
    }


    public (CaseUpdateDTO pcCaseToPatch, Case
        pcCaseEntity) GetCaseForPatch(Guid productId, Guid id,
        bool productTrackChanges, bool pcCaseTrackChanges)
    {
        var product = _repository.Product.GetProduct(productId, productTrackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
        var pcCaseEntity = _repository.Case.GetCase(productId, id,
        pcCaseTrackChanges);
        if (pcCaseEntity is null)
            throw new CaseNotFoundException(productId);
        var pcCaseToPatch = _mapper.Map<CaseUpdateDTO>(pcCaseEntity);
        return (pcCaseToPatch, pcCaseEntity);
    }

    public void SaveChangesForPatch(CaseUpdateDTO pcCaseToPatch, Case
    pcCaseEntity)
    {
        _mapper.Map(pcCaseToPatch, pcCaseEntity);
        _repository.Save();
    }
}
