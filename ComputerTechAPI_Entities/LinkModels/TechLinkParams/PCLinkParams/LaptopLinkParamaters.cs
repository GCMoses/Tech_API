using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;

public record LaptopLinkParameters(LaptopParams laptopParams, HttpContext Context);

