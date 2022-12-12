using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IGamingLinks;

public interface IGamingConsoleLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<GamingConsoleDTO> gamingConsoleDTO,
    string fields, Guid productId, HttpContext httpContext);
}
