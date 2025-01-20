namespace TobaccoDMAuthorization.DmRoles.Requests;

/// <summary>
/// 创建用户
/// </summary>
/// <param name="RoleName"></param>
/// <param name="ChildrenRoleNames"></param>
public record CreateDmRoleRequest(string RoleName,string[] ChildrenRoleNames);