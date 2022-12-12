using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;

public interface ICPULinks
{
    LinkResponse TryGenerateLinks(IEnumerable<CPUDTO> cpuDTO,
    string fields, Guid productId, HttpContext httpContext);
}
