using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_TechService.Contracts.PCService;

public interface ILaptopService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetLaptopsAsync(Guid productId,
        LaptopLinkParameters linkParameters, bool trackChanges);
    Task<LaptopDTO> GetLaptopAsync(Guid productId, Guid id, bool trackChanges);
    Task<LaptopDTO> CreateLaptopForProductAsync(Guid productId,
       LaptopCreateDTO laptopCreate, bool trackChanges);
    Task DeleteLaptopForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateLaptopForProductAsync(Guid productId, Guid id,
        LaptopUpdateDTO laptopUpdate, bool productTrackChanges, bool laptopTrackChanges);
    Task<(LaptopUpdateDTO laptopToPatch, Laptop laptopEntity)> GetLaptopForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool laptopTrackChanges);
    Task SaveChangesForPatchAsync(LaptopUpdateDTO laptopToPatch, Laptop laptopEntity);
}
