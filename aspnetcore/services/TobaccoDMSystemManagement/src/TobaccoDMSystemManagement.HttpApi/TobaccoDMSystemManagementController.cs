using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.Domain;

namespace TobaccoDMSystemManagement;

[ApiController]
[Area(TobaccoDMSystemManagementConsts.ApplicationName)]
[Route("api/TobaccoDMSystemManagement/[controller]/[action]")]
public abstract class TobaccoDMSystemManagementController: DedsiControllerBase;
