using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMAuthorization.DmRoles.Commands;
using TobaccoDMAuthorization.Repositories.DmRoles;

namespace TobaccoDMAuthorization.DmRoles.CommandHandlers;

/// <summary>
/// 创建用户
/// </summary>
public class CreateDmRoleCommandHandler(IDmRoleRepository dmRoleRepository): DedsiCommandHandler<CreateDmRoleCommand, bool>
{
    public override async Task<bool> Handle(CreateDmRoleCommand command, CancellationToken cancellationToken)
    {
        var dmRole = new DmRole(GuidGenerator.Create(), command.RoleName);
        foreach (var childRoleName in command.ChildrenRoleNames)
        {
            dmRole.AddChildrenRole(new DmRole(GuidGenerator.Create(), childRoleName));
        }

        await dmRoleRepository.InsertAsync(dmRole, cancellationToken: cancellationToken);
        
        return true;
    }
}