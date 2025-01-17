using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TobaccoDMAuthorization.DmUsers;
using TobaccoDMAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;

namespace TobaccoDMAuthorization;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class TobaccoDMAuthorizationInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<TobaccoDMAuthorizationDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
        
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<DmUser>(abpEntityOptions =>
            {
                abpEntityOptions.DefaultWithDetailsFunc = query => query
                    .Include(o => o.UserRoles);
            });

        });

    }
}