using Microsoft.Extensions.Configuration;
using Serilog;

namespace Auto_Repair_Managment.Infrastructure;

public static class LoggingConfigurator
{
    private const string SettingsFileName = "appsettings.json";

    public static void ConfigureLogger()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(SettingsFileName, optional: false)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }
}
