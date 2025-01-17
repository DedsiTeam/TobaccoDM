using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TobaccoDMAuthorization;

[DependsOn(
    typeof(TobaccoDMAuthorizationUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class TobaccoDMAuthorizationHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TobaccoDMAuthorizationHttpApiModule).Assembly);
        });
    }

}