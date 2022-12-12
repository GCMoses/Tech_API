using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using System.Threading.Tasks;

namespace ComputerTechAPI_TechService.Contracts.IPCComponentService;

public interface IMotherboardService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetMotherboardsAsync(Guid productId,
        MotherboardLinkParameters linkParameters, bool trackChanges);
    Task<MotherboardDTO> GetMotherboardAsync(Guid productId, Guid id, bool trackChanges);
    Task<MotherboardDTO> CreateMotherboardForProductAsync(Guid productId,
       MotherboardCreateDTO motherboardCreate, bool trackChanges);
    Task DeleteMotherboardForProductAsync(Guid productId, Guid id, bool trackChanges);
    Task UpdateMotherboardForProductAsync(Guid productId, Guid id,
        MotherboardUpdateDTO motherboardUpdate, bool productTrackChanges, bool motherboardTrackChanges);
    Task<(MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity)> GetMotherboardForPatchAsync(
        Guid productId, Guid id, bool productTrackChanges, bool motherboardTrackChanges);
    Task SaveChangesForPatchAsync(MotherboardUpdateDTO motherboardToPatch, Motherboard motherboardEntity);
}
