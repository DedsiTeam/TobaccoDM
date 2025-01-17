using Volo.Abp.Domain.Entities;

namespace TobaccoDMAuthorization.DmUsers;

/// <summary>
/// 用户信息
/// </summary>
public class DmUser: Entity<Guid>
{
    protected DmUser()
    {
        
    }

    public DmUser(Guid id, string userName, string password, string loginAccount, string email) : base(id)
    {
        ChangeUserName(userName);
        ChangeLoginAccount(loginAccount);
        ChangeEmail(email);

        var key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
        var iv = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
        EncryptionKey = new DmUserEncryptionKey(key, iv);
        
        ChangePassword(password);
    }
    
    /// <summary>
    /// 加密密钥
    /// </summary>
    public DmUserEncryptionKey EncryptionKey { get; private set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; private set; }

    public void ChangeUserName(string newUserName)
    {
        UserName = newUserName;
    }
    
    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newPassword">未加密前的原文</param>
    public void ChangePassword(string newPassword)
    {
        Password = EncryptionKey.Encryption.Encrypt(newPassword);
    }

    /// <summary>
    /// 获取解密后的密码
    /// </summary>
    /// <returns></returns>
    public string GetDecryptPassword()
    {
        return EncryptionKey.Encryption.Decrypt(Password);
    }
    
    /// <summary>
    /// 登录账号
    /// </summary>
    public string LoginAccount { get; private set; }

    public void ChangeLoginAccount(string newLoginAccount)
    {
        LoginAccount = newLoginAccount;
    }
    
    /// <summary>
    /// 邮箱地址
    /// </summary>
    public string Email { get; private set; }

    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
    }
    
    /// <summary>
    /// 用户拥有的角色
    /// </summary>
    public ICollection<DmUserRole> UserRoles { get; private set; } = new List<DmUserRole>();

    public void AddRole(DmUserRole role)
    {
        // 不存在就添加
        if (!UserRoles.Any(x => x.RoleName == role.RoleName && x.RoleId == role.RoleId))
        {
            UserRoles.Add(role);
        }
    }
}

/// <summary>
/// 加密密钥
/// </summary>
/// <param name="Key"></param>
/// <param name="Iv"></param>
public record DmUserEncryptionKey(string Key, string Iv)
{
    /// <summary>
    /// 忽略字段：尽在程序中使用
    /// </summary>
    public EncryptionHelper Encryption => new(Key, Iv);
}