using Microsoft.EntityFrameworkCore;
using TobaccoDMAuthorization.DmRoles;
using TobaccoDMAuthorization.DmUsers;
using Volo.Abp;

namespace TobaccoDMAuthorization.EntityFrameworkCore;

public static class TobaccoDMAuthorizationDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<DmUser>(b =>
        {
            b.ToTable("DmUsers", TobaccoDMAuthorizationDomainOptions.DbSchemaName);
            b.HasKey(a => a.Id);

            b.OwnsOne(a => a.EncryptionKey, a =>
            {
                a.Property(p => p.Key).HasColumnName("EncryptionKey");
                a.Property(p => p.Iv).HasColumnName("EncryptionIv");
                
                // 忽略字段：只在程序中使用
                a.Ignore(p => p.Encryption);
            });
            
            // 用户拥有的角色
            b.HasMany(e => e.UserRoles)
                .WithOne()
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(a => a.UserId)
                .IsRequired();
        });

        builder.Entity<DmUserRole>(b =>
        {
            b.ToTable("DmUserRoles", TobaccoDMAuthorizationDomainOptions.DbSchemaName);

            b.HasKey(c => new { c.UserId, c.RoleId });
        });
        
        builder.Entity<DmRole>(b =>
        {
            b.ToTable("DmRoles", TobaccoDMAuthorizationDomainOptions.DbSchemaName);
            
            b.HasKey(c => c.Id);
        });
    }
}