using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace TobaccoDMAuthorization;

[ApiController]
[Area(TobaccoDMAuthorizationDomainOptions.ApplicationName)]
[Route("api/TobaccoDMAuthorization/[controller]/[action]")]
public abstract class TobaccoDMAuthorizationController : DedsiControllerBase;