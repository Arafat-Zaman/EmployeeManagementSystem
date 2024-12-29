using Serilog;

namespace EmployeeManagementSystem.Infrastructure.Logging
{
    public static class SerilogLogger
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
