﻿using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

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
}
