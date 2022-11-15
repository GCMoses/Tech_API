using ComputerTechAPI_Contracts;
using NLog;

namespace ComputerTechAPI_LoggingServices;

public class LogsManager : ILogsManager
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();
    public LogsManager()
      {
      }
public void LogDebug(string message) => logger.Debug(message);
public void LogError(string message) => logger.Error(message);
public void LogInfo(string message) => logger.Info(message);
public void LogWarn(string message) => logger.Warn(message);
}
