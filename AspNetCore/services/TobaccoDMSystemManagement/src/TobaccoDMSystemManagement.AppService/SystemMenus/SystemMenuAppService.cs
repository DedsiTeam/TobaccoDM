using TobaccoDMSystemManagement.Domain.SystemMenus;
using TobaccoDMSystemManagement.Infrastructure.Repositories.SystemMenus;

namespace TobaccoDMSystemManagement.AppService.SystemMenus
{
    public interface ISystemMenuAppService : ITobaccoDMSystemManagementAppService
    {
        Task<bool> ChangeSystemMenu();
    }

    public class SystemMenuAppService(ISystemMenuRepository _systemMenusRepository) : TobaccoDMSystemManagementAppService, ISystemMenuAppService
    {
        public Task<bool> ChangeSystemMenu()
        {
           return  _systemMenusRepository.InsertAsync(new SystemMenu());
        }
    }
}
