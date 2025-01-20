using TobaccoDMSystemManagement.AppService.SystemLogs.Dtos;
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Infrastructure.Repositories.SystemLogs;
using TobaccoDMSystemManagement.Infrastructure.Utils;
using Volo.Abp.Guids;

namespace TobaccoDMSystemManagement.AppService.SystemLogs;

public interface ISystemLogAppService: ITobaccoDMSystemManagementAppService
{
    Task<bool> ChangeSystemLog(SystemLogDto dto);
}

public class SystemLogAppService(ISystemLogRepository systemLogRepository) : TobaccoDMSystemManagementAppService, ISystemLogAppService
{
    

    Task<bool> ISystemLogAppService.ChangeSystemLog(SystemLogDto dto)
    {
        SystemLog Log = MapsterConfig.MapsterTo<SystemLogDto, SystemLog>(dto);
        Log.CreateUlidTime(GuidGenerator.Create());
        return systemLogRepository.InsertAsync(Log);
    }
}
