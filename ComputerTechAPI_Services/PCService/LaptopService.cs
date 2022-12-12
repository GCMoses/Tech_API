using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_TechService.Contracts.PCService;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Contracts.ILinks.IPCLinks;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Services.PCService;

public class LaptopService : ILaptopService
{
    private readonly IRepositoryManager _repository;
    private readonly ILogsManager _logger;
    private readonly IMapper _mapper;
    private readonly ILaptopLinks _laptopLinks;
    public LaptopService(IRepositoryManager repository, ILogsManager
    logger, IMapper mapper, ILaptopLinks laptopLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _laptopLinks = laptopLinks;
    }

    public async Task<(LinkResponse linkResponse, MetaData metaData)>
     GetLaptopsAsync(Guid productId, LaptopLinkParameters linkParameters, bool trackChanges)
    {
        if (!linkParameters.laptopParams.RatingRange)
            throw new RatingRangeBadRequestException();

        await CheckIfProductExists(productId, trackChanges);
        var laptopsWithMetaData = await _repository.Laptop
        .GetLaptopsAsync(productId, linkParameters.laptopParams, trackChanges);

        var laptopsDTO = _mapper.Map<IEnumerable<LaptopDTO>>
            (laptopsWithMetaData);
        var links = _laptopLinks.TryGenerateLinks(laptopsDTO,
        linkParameters.laptopParams.Fields, productId, linkParameters.Context);

        return (linkResponse: links, metaData: laptopsWithMetaData.MetaData);
    }
    public async Task<LaptopDTO> GetLaptopAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var laptopDb = await GetLaptopForProductAndCheckIfItExists(productId, id, trackChanges);

        var laptopDTO = _mapper.Map<LaptopDTO>(laptopDb);
        return laptopDTO;
    }

    public async Task<LaptopDTO> CreateLaptopForProductAsync(Guid productId,
        LaptopCreateDTO laptopCreate, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var laptopEntity = _mapper.Map<Laptop>(laptopCreate);

        _repository.Laptop.CreateLaptopForProduct(productId, laptopEntity);
        await _repository.SaveAsync();

        var laptopToReturn = _mapper.Map<LaptopDTO>(laptopEntity);

        return laptopToReturn;
    }

    public async Task DeleteLaptopForProductAsync(Guid productId, Guid id, bool trackChanges)
    {
        await CheckIfProductExists(productId, trackChanges);

        var laptopDb = await GetLaptopForProductAndCheckIfItExists(productId, id, trackChanges);

        _repository.Laptop.DeleteLaptop(laptopDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateLaptopForProductAsync(Guid productId, Guid id, LaptopUpdateDTO
        laptopUpdate, bool productTrackChanges, bool laptopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var laptopDb = await GetLaptopForProductAndCheckIfItExists(productId, id, laptopTrackChanges);

        _mapper.Map(laptopUpdate, laptopDb);
        await _repository.SaveAsync();
    }

    public async Task<(LaptopUpdateDTO laptopToPatch, Laptop laptopEntity)> GetLaptopForPatchAsync
        (Guid productId, Guid id, bool productTrackChanges, bool laptopTrackChanges)
    {
        await CheckIfProductExists(productId, productTrackChanges);

        var laptopDb = await GetLaptopForProductAndCheckIfItExists(productId, id, laptopTrackChanges);

        var laptopToPatch = _mapper.Map<LaptopUpdateDTO>(laptopDb);

        return (laptopToPatch: laptopToPatch, laptopEntity: laptopDb);
    }

    public async Task SaveChangesForPatchAsync(LaptopUpdateDTO laptopToPatch, Laptop laptopEntity)
    {
        _mapper.Map(laptopToPatch, laptopEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    private async Task<Laptop> GetLaptopForProductAndCheckIfItExists
        (Guid productId, Guid id, bool trackChanges)
    {
        var laptopDb = await _repository.Laptop.GetLaptopAsync(productId, id, trackChanges);
        if (laptopDb is null)
            throw new LaptopNotFoundException(id);

        return laptopDb;
    }

}