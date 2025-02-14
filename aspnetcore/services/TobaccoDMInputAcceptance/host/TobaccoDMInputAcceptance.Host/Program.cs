using Serilog;
using Serilog.Events;

namespace TobaccoDMInputAcceptance;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Async(c => c.File(path:"Logs/logs.txt", rollingInterval:RollingInterval.Hour, retainedFileCountLimit: null))
            .WriteTo.Async(c => c.Console())
            .CreateBootstrapLogger();
        
        try
        {
            Log.Information("ProjectName web host.");
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
                        .WriteTo.Async(c => c.File(path:"Logs/logs.txt", rollingInterval:RollingInterval.Hour, retainedFileCountLimit: null))
                        .WriteTo.Async(c => c.Console());
                });
            
            
            // Minimal Apis
            builder.Services.AddEndpointsApiExplorer();
            
            await builder.AddApplicationAsync<TobaccoDMInputAcceptanceHostModule>();
            
            var app = builder.Build();
            
            // Minimal Apis
            app.MapTobaccoDMInputAcceptanceMinimalApis();
            
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "ProjectName Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
