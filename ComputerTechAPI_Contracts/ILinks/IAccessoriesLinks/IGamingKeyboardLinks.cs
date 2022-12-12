using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;

public interface IGamingKeyboardLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<GamingKeyboardDTO> gamingKeyboardDTO,
    string fields, Guid productId, HttpContext httpContext);
}
