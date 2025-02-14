using System;
using System.IO;
using Microsoft.Extensions.Logging;


namespace CleanScramble.Tests;
public class FileLogger : ILogger
{
    private readonly string _filePath;
    private static readonly object _lock = new();

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public IDisposable BeginScope<TState>(TState state) => null;
    public bool IsEnabled(LogLevel logLevel) => true;
    
    public void Log<TState>(LogLevel logLevel, 
        EventId eventId, 
        TState state, 
        Exception exception, 
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logLevel}] {formatter(state, exception)}";
        lock (_lock)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}

public class FileLoggerProvider : ILoggerProvider
{
    private readonly string _filePath;
    public FileLoggerProvider(string filePath)
    {
        _filePath = filePath;
    }
    
    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(_filePath);
    }

    public void Dispose() { }
}