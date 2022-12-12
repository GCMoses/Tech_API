using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;

public interface IPSULinks
{
    LinkResponse TryGenerateLinks(IEnumerable<PSUDTO> psuDTO,
    string fields, Guid productId, HttpContext httpContext);
}
