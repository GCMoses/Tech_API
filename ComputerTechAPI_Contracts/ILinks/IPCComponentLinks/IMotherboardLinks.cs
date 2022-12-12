using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;

public interface IMotherboardLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<MotherboardDTO> motherboardDTO,
    string fields, Guid productId, HttpContext httpContext);
}
