using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TobaccoDMAuthorization;

[DependsOn(
    // TobaccoDMAuthorization
    typeof(TobaccoDMAuthorizationDomainModule),
    typeof(TobaccoDMAuthorizationInfrastructureModule),
    
    typeof(DedsiDddCQRSModule)
)]
public class TobaccoDMAuthorizationUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}