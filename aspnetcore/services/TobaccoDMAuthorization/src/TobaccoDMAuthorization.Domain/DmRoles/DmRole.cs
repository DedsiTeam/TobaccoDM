using Volo.Abp.Domain.Entities;

namespace TobaccoDMAuthorization.DmRoles;

/// <summary>
/// 角色
/// </summary>
public class DmRole: Entity<Guid>
{
    protected DmRole()
    {
        
    }
    public DmRole(Guid id, string roleName): base(id)
    {
        RoleName = roleName;
        IsEnable = true;
    }
    
    public Guid? ParentId { get; protected set; }

    public void SetParentId(Guid? parentId)
    {
        ParentId = parentId;
    }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; private set; }
    
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsEnable { get; private set; }
    
    /// <summary>
    /// 当前角色下的子角色
    /// </summary>
    public ICollection<DmRole> ChildrenRoles { get; protected set; } = new List<DmRole>();

    public void AddChildrenRole(DmRole dmRole)
    {
        dmRole.SetParentId(Id);
        ChildrenRoles.Add(dmRole);
    }
}