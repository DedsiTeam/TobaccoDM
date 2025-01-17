using Microsoft.Extensions.DependencyInjection;
using TobaccoDMSystemManagement.AppService;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.HttpApi;

[DependsOn(
    typeof(TobaccoDMSystemManagementCoreModule),
    
    typeof(AbpAspNetCoreMvcModule)
)]
public class TobaccoDMSystemManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TobaccoDMSystemManagementHttpApiModule).Assembly);
        });
    }
}
