using Dedsi.Ddd.CQRS.Commands;

namespace TobaccoDMAuthorization.DmUsers.Commands;

/// <summary>
/// 创建用户
/// </summary>
/// <param name="UserName"></param>
/// <param name="LoginAccount"></param>
/// <param name="Email"></param>
public record CreateDmUserCommand(string UserName,string LoginAccount, string Email, DmUserRoleItem[] DmUserRoles) : DedsiCommand<bool>;

/// <summary>
/// 用户的角色
/// </summary>
/// <param name="RoleId"></param>
/// <param name="RoleName"></param>
public record DmUserRoleItem(Guid RoleId,string RoleName);