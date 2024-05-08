using System.IO;

namespace TestTaskDinamika.Wpf.Logger;
public static class SimpleLogger
{
    private static readonly string _appPath = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string _logFolderName = "Logs";
    public static void Log(string message)
    {
        var folderPath = Path.Combine(_appPath, _logFolderName);

        Directory.CreateDirectory(folderPath);

        var logFileName = $"log_{DateTime.Now:dd.MM.yyyy-HH.mm.ss.fff}.txt";
        var logFilePath = Path.Combine(folderPath, logFileName);

        File.WriteAllText(logFilePath, message);
    }
}
