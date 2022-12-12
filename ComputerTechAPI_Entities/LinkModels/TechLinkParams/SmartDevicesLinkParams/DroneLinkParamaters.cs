using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;

public record DroneLinkParameters(DroneParams droneParams, HttpContext Context);

