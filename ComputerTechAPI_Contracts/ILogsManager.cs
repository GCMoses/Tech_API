namespace ComputerTechAPI_Contracts;

public interface ILogsManager
{
    void LogInfo(string message);
    void LogWarn(string message);
    void LogDebug(string message);
    void LogError(string message);
}
