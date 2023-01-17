using enzotlucas.DevKit.Logger.LoggerManagers;
using Microsoft.Extensions.Logging;

namespace enzotlucas.DevKit.Logger.Loggers
{
    /// <summary>
    /// Console based logging, only for tests or debugging porpouse
    /// </summary>
    public sealed class ConsoleLoggerManager : ILoggerManager
    {
        public void Log(Log log)
        {
            switch (log.LogLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                    PrintInformation(log);
                    break;
                case LogLevel.None:
                    break;
                default:
                    PrintError(log);
                    break;
            }
        }

        private void PrintError(Log log)
        {
            Print(log, log.LogLevel == LogLevel.Warning ? ConsoleColor.Yellow : ConsoleColor.Red);
        }

        private void PrintInformation(Log log)
        {
            Print(log, ConsoleColor.White);
        }

        private void Print(Log log, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(log);

            Console.ResetColor();
        }

        public void Dispose()
        {

        }
    }
}
