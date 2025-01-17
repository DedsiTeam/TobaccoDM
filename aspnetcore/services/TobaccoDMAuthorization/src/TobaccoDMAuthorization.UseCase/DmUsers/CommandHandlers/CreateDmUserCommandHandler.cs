using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMAuthorization.DmUsers.Commands;
using TobaccoDMAuthorization.Repositories.DmUsers;

namespace TobaccoDMAuthorization.DmUsers.CommandHandlers;

/// <summary>
/// 创建用户
/// </summary>
public class CreateDmUserCommandHandler(IDmUserRepository dmUserRepository): DedsiCommandHandler<CreateDmUserCommand, bool>
{
    public override async Task<bool> Handle(CreateDmUserCommand command, CancellationToken cancellationToken)
    {
        var dmUser = new DmUser(GuidGenerator.Create(), command.UserName,DmUserConsts.DefulatPpassWord, command.LoginAccount, command.Email);
        
        // 用户的角色
        foreach (var item in command.DmUserRoles)
        {
            dmUser.AddRole(new DmUserRole(dmUser.Id, item.RoleId, item.RoleName));
        }

        await dmUserRepository.InsertAsync(dmUser, false, cancellationToken);
        return true;
    }
}