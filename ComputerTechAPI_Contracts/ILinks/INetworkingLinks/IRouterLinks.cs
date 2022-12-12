using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.INetworkingLinks;

public interface IRouterLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<RouterDTO> routerDTO,
    string fields, Guid productId, HttpContext httpContext);
}
