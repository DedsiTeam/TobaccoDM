using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Mvc;
using TobaccoDMAuthorization.DmRoles.Commands;
using TobaccoDMAuthorization.DmRoles.Requests;

namespace TobaccoDMAuthorization.DmRoles;

/// <summary>
/// 角色管理
/// </summary>
public class DmRoleController(IDedsiMediator dedsiMediator): TobaccoDMAuthorizationController
{
    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> CreateAsync(CreateDmRoleRequest request)
    {
        return dedsiMediator.PublishAsync(new CreateDmRoleCommand(request.RoleName, request.ChildrenRoleNames), HttpContext.RequestAborted);
    }
}