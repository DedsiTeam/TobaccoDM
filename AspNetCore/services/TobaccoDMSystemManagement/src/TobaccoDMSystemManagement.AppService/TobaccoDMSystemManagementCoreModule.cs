using TobaccoDMSystemManagement.Domain;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.AppService;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule)
)]
public class TobaccoDMSystemManagementCoreModule : AbpModule;