using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.IPCLinks;

public interface ILaptopLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<LaptopDTO> laptopDTO,
    string fields, Guid productId, HttpContext httpContext);
}
