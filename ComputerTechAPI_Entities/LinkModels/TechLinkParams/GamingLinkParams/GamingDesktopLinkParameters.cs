﻿using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
public record GamingDesktopLinkParameters(GamingDesktopParams gamingDesktopParams, HttpContext Context);
