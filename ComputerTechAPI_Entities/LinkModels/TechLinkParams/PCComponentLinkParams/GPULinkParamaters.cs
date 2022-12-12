using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;

public record GPULinkParameters(GPUParams gpuParams, HttpContext Context);

