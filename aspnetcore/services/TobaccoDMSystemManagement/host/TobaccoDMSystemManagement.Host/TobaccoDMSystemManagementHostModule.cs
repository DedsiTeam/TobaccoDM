using Microsoft.AspNetCore.Cors;
using Swashbuckle.AspNetCore.SwaggerUI;
using TobaccoDMSystemManagement.Domain;
using TobaccoDMSystemManagement.HttpApi;
using TobaccoDMSystemManagement.Infrastructure;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Host;

[DependsOn(
    typeof(TobaccoDMSystemManagementHttpApiModule),
    typeof(TobaccoDMSystemManagementInfrastructureModule),

    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
public class TobaccoDMSystemManagementHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostEnvironment = context.Services.GetAbpHostEnvironment();

        // 日志
        Configure<AbpAuditingOptions>(opt =>
        {
            opt.ApplicationName = TobaccoDMSystemManagementConsts.ApplicationName;
            opt.IsEnabledForGetRequests = true;
        });
        
        // 时间格式 
        Configure<AbpJsonOptions>(opt =>
        {
            opt.OutputDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        });

        // 跨域
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? []
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // Swagger
        context.Services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TobaccoDMSystemManagement.AppService.xml"), true);
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TobaccoDMSystemManagement.HttpApi.xml"), true);
        });
        
        Configure<AbpAntiForgeryOptions>(options =>
        {
            options.TokenCookie.Expiration = TimeSpan.FromDays(365);
            options.AutoValidateIgnoredHttpMethods.Remove("POST");
            options.AutoValidateFilter =
                type => !type.Namespace.StartsWith("TobaccoDMSystemManagement");
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
       
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelExpandDepth(-1);
        });

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.UseAuditing();
        app.UseConfiguredEndpoints(endpoints =>
        {
            // AuthorizeAttribute
            // endpoints.MapControllers().RequireAuthorization();
        });
    }
}

