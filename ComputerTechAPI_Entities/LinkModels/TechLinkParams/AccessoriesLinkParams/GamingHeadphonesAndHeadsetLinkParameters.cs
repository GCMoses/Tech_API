﻿using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;

public record GamingHeadphonesAndHeadsetLinkParameters(GamingHeadphonesAndHeadsetParams gamingHeadphonesAndHeadsetParams,
                                                       HttpContext Context);
