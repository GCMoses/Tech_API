using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;

public interface IDroneLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<DroneDTO> droneDTO, string fields, Guid productId, HttpContext httpContext);
}
