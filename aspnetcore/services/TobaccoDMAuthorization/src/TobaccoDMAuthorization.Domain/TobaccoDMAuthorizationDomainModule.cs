using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace TobaccoDMAuthorization;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class TobaccoDMAuthorizationDomainModule : AbpModule
{
    
}