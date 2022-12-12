using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.NetworkingTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.NetworkingLinkParams;

public record RouterLinkParameters(RouterParams routerParams, HttpContext Context);

