using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IPCLinks;

public interface IDesktopLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<DesktopDTO> desktopDTO,
    string fields, Guid productId, HttpContext httpContext);
}
