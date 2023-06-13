using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace TheDialgaTeam.Microsoft.Extensions.Logging.Action;

public sealed class ActionLogger : ILogger
{
    private readonly string _name;
    private readonly LoggingTemplateFormatter _formatter;
    private readonly ActionLoggerConfiguration _configuration;

    [ThreadStatic]
    private static StringWriter? _stringWriter;

    public ActionLogger(string name, LoggingTemplateFormatter formatter, ActionLoggerConfiguration configuration)
    {
        _name = name;
        _formatter = formatter;
        _configuration = configuration;
    }
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        
        _stringWriter ??= new StringWriter();
        var logEntry = new LogEntry<TState>(logLevel, _name, eventId, state, exception, formatter);
        _formatter.Write(in logEntry, null, _stringWriter);
        
        var sb = _stringWriter.GetStringBuilder();
        if (sb.Length == 0) return;
        
        var computedAnsiString = sb.ToString();
        sb.Clear();
        
        if (sb.Capacity > 1024)
        {
            sb.Capacity = 1024;
        }

        _configuration.RegisteredActionLogger?.Invoke(computedAnsiString);
    }
    
    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }
    
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return default;
    }
}