using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.IPCComponentService;

namespace ComputerTechAPI_Services.PCComponentService;

public class MotherboardService : IMotherboardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    public MotherboardService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<MotherboardDTO> GetMotherboards(Guid productId, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var motherboardDb = _repository.Motherboard.GetMotherboards(productId, trackChanges);
        var motherboardDTO = _mapper.Map<IEnumerable<MotherboardDTO>>(motherboardDb);
        return motherboardDTO;
    }


    public MotherboardDTO GetMotherboard(Guid productId, Guid id, bool trackChanges)
    {
        var product = _repository.Product.GetProduct(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        var motherboardDb = _repository.Motherboard.GetMotherboard(productId, id, trackChanges);
        if (motherboardDb is null)
            throw new MotherboardNotFoundException(id);

        var motherboard = _mapper.Map<MotherboardDTO>(motherboardDb);
        return motherboard;
    }
}