using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace TobaccoDMSystemManagement.AppService;

public interface ITobaccoDMSystemManagementAppService : ITransientDependency;

public class TobaccoDMSystemManagementAppService : ITobaccoDMSystemManagementAppService
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; }

    protected IGuidGenerator GuidGenerator => LazyServiceProvider.LazyGetRequiredService<IGuidGenerator>();
}
