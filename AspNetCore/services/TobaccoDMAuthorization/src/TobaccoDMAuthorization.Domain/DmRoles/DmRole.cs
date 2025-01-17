using Volo.Abp.Domain.Entities;

namespace TobaccoDMAuthorization.DmRoles;

/// <summary>
/// 角色
/// </summary>
public class DmRole: Entity<Guid>
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; private set; }
    
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsEnable { get; private set; }
}