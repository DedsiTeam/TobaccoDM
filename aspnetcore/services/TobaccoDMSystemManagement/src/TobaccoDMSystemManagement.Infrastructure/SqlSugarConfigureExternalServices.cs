using System.Reflection;
using SqlSugar;
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Domain.SystemMenus;

namespace TobaccoDMSystemManagement.Infrastructure;

public static class SqlSugarConfigureExternalServices
{

    public static ConfigureExternalServices Get()
    {
        Action<PropertyInfo, EntityColumnInfo> EntityServiceAction = (s, p) =>
        {
            // 是id的设为主键
            if (p.PropertyName.ToLower() == "id")
            {
                p.IsPrimarykey = true;
            }
        };

        Action<Type, EntityInfo> EntityNameServiceAction = (type, entity) =>
        {
            if (type.Name == nameof(SystemLog))
            {
                entity.DbTableName = "system_log";
            }
            else if (type.Name == nameof(SystemMenu))
            {
                entity.DbTableName = "system_menu";
            }
        };
       

        return new ConfigureExternalServices()
        {
            EntityService = EntityServiceAction,
            EntityNameService = EntityNameServiceAction
        };
    }
}