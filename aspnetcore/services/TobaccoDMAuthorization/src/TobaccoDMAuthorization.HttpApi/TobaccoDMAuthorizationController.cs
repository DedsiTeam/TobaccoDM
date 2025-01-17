using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace TobaccoDMAuthorization;

[ApiController]
[Area(TobaccoDMAuthorizationDomainOptions.ApplicationName)]
[Route("api/TobaccoDMAuthorization/[controller]/[action]")]
// [ApiExplorerSettings(GroupName = TobaccoDMAuthorizationDomainOptions.ApplicationName)]
public abstract class TobaccoDMAuthorizationController : DedsiControllerBase;