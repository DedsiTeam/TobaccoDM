using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using TobaccoDMSystemManagement.Domain.SystemMenus;

namespace TobaccoDMSystemManagement.Infrastructure.Repositories.SystemMenus
{

    public interface ISystemMenuRepository:ISqlSugarRepository<SystemMenu>;

    public class SystemMenuRepository(ISqlSugarClient sqlSugarClient): SqlSugarRepository<SystemMenu>(sqlSugarClient), ISystemMenuRepository
    {

    }
}
