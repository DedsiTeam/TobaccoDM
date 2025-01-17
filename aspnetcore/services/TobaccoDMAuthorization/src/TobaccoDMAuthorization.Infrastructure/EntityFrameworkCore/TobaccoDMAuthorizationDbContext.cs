using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TobaccoDMAuthorization.DmRoles;
using TobaccoDMAuthorization.DmUsers;
using Volo.Abp.Data;

namespace TobaccoDMAuthorization.EntityFrameworkCore;

[ConnectionStringName(TobaccoDMAuthorizationDomainOptions.ConnectionStringName)]
public class TobaccoDMAuthorizationDbContext(DbContextOptions<TobaccoDMAuthorizationDbContext> options) 
    : DedsiEfCoreDbContext<TobaccoDMAuthorizationDbContext>(options)
{
    /// <summary>
    /// 用户
    /// </summary>
    public DbSet<DmUser> DmUsers { get; set; }
    
    /// <summary>
    /// 角色
    /// </summary>
    public DbSet<DmRole> DmRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}