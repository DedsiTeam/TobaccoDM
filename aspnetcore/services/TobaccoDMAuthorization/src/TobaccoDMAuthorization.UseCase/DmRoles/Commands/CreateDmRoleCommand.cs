using Dedsi.Ddd.CQRS.Commands;
using FluentValidation;

namespace TobaccoDMAuthorization.DmRoles.Commands;

/// <summary>
/// 创建角色
/// </summary>
/// <param name="RoleName"></param>
/// <param name="ChildrenRoleNames"></param>
public record CreateDmRoleCommand(string RoleName, string[] ChildrenRoleNames) : DedsiCommand<bool>;

/// <summary>
/// 创建角色验证器
/// </summary>
public class CreateDmRoleCommandValidator : AbstractValidator<CreateDmRoleCommand>
{
    public CreateDmRoleCommandValidator()
    {
        RuleFor(x => x.RoleName).MaximumLength(20);
    }
}