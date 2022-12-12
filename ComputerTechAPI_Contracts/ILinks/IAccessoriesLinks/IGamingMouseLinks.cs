using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;

public interface IGamingMouseLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<GamingMouseDTO> gamingMouseDTO,
    string fields, Guid productId, HttpContext httpContext);
}
