using Serilog;
using Serilog.Events;

namespace TobaccoDMSystemManagement.Host;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            Log.Information("TobaccoDMSystemManagement web host.");
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    loggerConfiguration
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Async(c => c.File(path: "Logs/logs.txt", rollingInterval: RollingInterval.Hour, retainedFileCountLimit: null))
                        .WriteTo.Async(c => c.Console());
                });
            await builder.AddApplicationAsync<TobaccoDMSystemManagementHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "TobaccoDMAuthorization Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
