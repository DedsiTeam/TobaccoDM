﻿using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.Domain;
using Volo.Abp.AspNetCore.Mvc;

namespace TobaccoDMSystemManagement;

[ApiController]
[Area(TobaccoDMSystemManagementConsts.ApplicationName)]
[Route("api/TobaccoDMSystemManagement/[controller]/[action]")]
public abstract class TobaccoDMSystemManagementController: AbpController;

[ApiController]
[Area(TobaccoDMSystemManagementConsts.ApplicationName)]
[Route("api-public/TobaccoDMSystemManagement/[controller]/[action]")]
public abstract class TobaccoDMSystemManagementPublicController: AbpController;