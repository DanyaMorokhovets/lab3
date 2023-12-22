using System;
using System.IO;

// Singleton для глобальної точки доступу до бази даних
public sealed class DbManager
{
    private static readonly DbManager instance = new DbManager();
    private DbManager() { }

    public static DbManager Instance => instance;

    public void Connect()
    {
        Console.WriteLine("Connected to the database.");
    }

    // Додайте інші методи для роботи з базою даних за необхідності
}

// Singleton для глобальної точки доступу до репозиторію для збереження документів
public sealed class DocumentSaver
{
    private static readonly DocumentSaver instance = new DocumentSaver();
    private DocumentSaver() { }

    public static DocumentSaver Instance => instance;

    public void SaveDocument(string document)
    {
        Console.WriteLine($"Document saved: {document}");
    }

    // Додайте інші методи для роботи з репозиторієм за необхідності
}

// Singleton для логування операцій у процесі роботи з програмою
public sealed class Logger
{
    private static readonly Logger instance = new Logger();
    private StreamWriter logFile;

    private Logger()
    {
        logFile = new StreamWriter("log.txt", true);
    }

    public static Logger Instance => instance;

    public void Log(string message)
    {
        string logEntry = $"{DateTime.Now}: {message}";
        Console.WriteLine(logEntry);
        logFile.WriteLine(logEntry);
    }

    public void CloseLogFile()
    {
        logFile.Close();
    }

    // Додайте інші методи для роботи з логуванням за необхідності
}

class Program
{
    static void Main()
    {
        // Використання глобальних точок доступу
        DbManager.Instance.Connect();
        DocumentSaver.Instance.SaveDocument("Sample Document");

        // Використання логера
        Logger.Instance.Log("User performed an action.");

        // Закриваємо програму
        Logger.Instance.CloseLogFile();
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
