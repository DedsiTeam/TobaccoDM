using Dedsi.Ddd.CQRS.Commands;
using FluentValidation;

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

/// <summary>
/// 创建用户的验证器
/// </summary>
public class CreateDmUserCommandValidator : AbstractValidator<CreateDmUserCommand>
{
    public CreateDmUserCommandValidator()
    {
        RuleFor(x => x.UserName).Length(2, 6);
        RuleFor(x => x.LoginAccount).Length(10, 20);
        RuleFor(x => x.Email).EmailAddress();
    }
}