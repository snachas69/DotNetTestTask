using Serilog;
using Microsoft.Extensions.Configuration;

namespace DotNetTestTask.Utilities
{
    public static class Logger
    {
        private static Serilog.Core.Logger _logger;

        static Logger()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public static void Debug(string message) => _logger.Debug(message);
        public static void Information(string message) => _logger.Information(message);
        public static void Warning(string message) => _logger.Warning(message);
        public static void Error(string message) => _logger.Error(message);
        public static void Fatal(string message) => _logger.Fatal(message);

        public static void Dispose()
        {
            _logger?.Dispose();
            Log.CloseAndFlush();
        }
    }
}
