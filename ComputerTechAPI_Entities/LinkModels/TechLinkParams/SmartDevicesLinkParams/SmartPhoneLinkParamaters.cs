﻿using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDevicesParams;
using Microsoft.AspNetCore.Http;

namespace ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;

public record SmartPhoneLinkParameters(SmartPhoneParams smartPhoneParams, HttpContext Context);

