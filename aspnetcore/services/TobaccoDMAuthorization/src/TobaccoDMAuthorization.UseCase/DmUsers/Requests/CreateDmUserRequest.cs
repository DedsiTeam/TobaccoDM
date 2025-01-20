namespace TobaccoDMAuthorization.DmUsers.Requests;

/// <summary>
/// 创建用户入参
/// </summary>
/// <param name="UserName"></param>
/// <param name="LoginAccount"></param>
/// <param name="Email"></param>
/// <param name="RoleIds"></param>
public record CreateDmUserRequest(string UserName,string LoginAccount, string Email,Guid[] RoleIds);