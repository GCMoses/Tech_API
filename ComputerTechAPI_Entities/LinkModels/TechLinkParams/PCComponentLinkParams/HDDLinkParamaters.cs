using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;

public record HDDLinkParameters(HDDParams hddParams, HttpContext Context);

