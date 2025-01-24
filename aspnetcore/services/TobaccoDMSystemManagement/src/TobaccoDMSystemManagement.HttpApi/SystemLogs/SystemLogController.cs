using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.AppService.SystemLogs;
using TobaccoDMSystemManagement.AppService.SystemLogs.Dtos;

namespace TobaccoDMSystemManagement.SystemLogs;

public class SystemLogController(ISystemLogAppService systemLogAppService) : TobaccoDMSystemManagementController
{
    /// <summary>
    /// �������Ӧ�ó�������
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> ChangeSystemLog(SystemLogDto dto)=>systemLogAppService.ChangeSystemLog(dto);

}