using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IGamingLinks;

public interface IGamingDesktopLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<GamingDesktopDTO> gamingDesktopDTO,
    string fields, Guid productId, HttpContext httpContext);
}
