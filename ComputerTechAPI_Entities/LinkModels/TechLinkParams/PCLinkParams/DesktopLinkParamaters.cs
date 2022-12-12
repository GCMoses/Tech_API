using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;

public record DesktopLinkParameters(DesktopParams desktopParams, HttpContext Context);

