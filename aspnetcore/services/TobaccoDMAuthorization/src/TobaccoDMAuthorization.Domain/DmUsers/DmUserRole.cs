namespace TobaccoDMAuthorization.DmUsers;

/// <summary>
/// 用户拥有的角色
/// </summary>
public class DmUserRole
{
    protected DmUserRole()
    {
        
    }

    public DmUserRole(Guid userId, Guid roleId, string roleName)
    {
        UserId = userId;
        RoleId = roleId;
        RoleName = roleName;
        Enable();
    }
    
    /// <summary>
    /// 用户Id
    /// </summary>
    public Guid UserId { get; private set; }
    
    /// <summary>
    /// 角色Id
    /// </summary>
    public Guid RoleId { get; private set; }
    
    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; private set; }
    
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsEnable { get; private set; }

    /// <summary>
    /// 启用
    /// </summary>
    public void Enable()
    {
        IsEnable = true;
    }
    
    /// <summary>
    /// 禁用
    /// </summary>
    public void Forbidden()
    {
        IsEnable = false;
    }
}