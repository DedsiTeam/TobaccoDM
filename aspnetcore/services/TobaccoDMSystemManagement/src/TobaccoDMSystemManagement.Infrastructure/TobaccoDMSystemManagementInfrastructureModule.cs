﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using TobaccoDMSystemManagement.Domain;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Infrastructure;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule)
)]
public class TobaccoDMSystemManagementInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        context.Services.AddAbpDbContext<TobaccoDMSystemManagementDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });


        //var configuration = context.Services.GetConfiguration();
        
        //var connectionConfig = new ConnectionConfig
        //{
        //    DbType = DbType.MySql,
        //    ConnectionString = configuration.GetConnectionString(TobaccoDMSystemManagementConsts.ConnectionStringName),
        //    IsAutoCloseConnection = true,
        //    ConfigureExternalServices = SqlSugarConfigureExternalServices.Get()
        //};
        //context.Services.AddScoped<ISqlSugarClient>(s => new SqlSugarClient(connectionConfig));
    }
}
