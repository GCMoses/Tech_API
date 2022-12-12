using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_TechService.Contracts.IGamingService;

public interface IGamingLaptopService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetGamingLaptopsAsync(Guid productId,
        GamingLaptopLinkParameters linkParameters, bool trackChanges);
    Task<GamingLaptopDTO> GetGamingLaptopAsync(Guid productId, Guid id, bool trackChanges);
    Task<GamingLaptopDTO> CreateGamingLaptopForProductAsync(Guid productId,
        GamingLaptopCreateDTO gamingLaptopCreate, bool trackChanges);
    Task DeleteGamingLaptopForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateGamingLaptopForProductAsync(Guid productId, Guid id,
        GamingLaptopUpdateDTO gamingLaptopUpdate, bool productTrackChanges, bool gamingLaptopTrackChanges);
    Task<(GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop gamingLaptopEntity)> GetGamingLaptopForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool gamingLaptopTrackChanges);
    Task SaveChangesForPatchAsync(GamingLaptopUpdateDTO gamingLaptopToPatch, GamingLaptop gamingLaptopEntity);
}