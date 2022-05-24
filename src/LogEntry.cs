using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public readonly struct LogEntry
{
    /// <summary>Gets the LogLevel</summary>
    public LogLevel LogLevel { get; }

    /// <summary>Gets the log category</summary>
    public string Category { get; }

    /// <summary>Gets the log EventId</summary>
    public EventId EventId { get; }

    /// <summary>Gets the log exception</summary>
    public Exception? Exception { get; }

    public LogEntry(LogLevel logLevel, string category, EventId eventId, Exception? exception)
    {
        LogLevel = logLevel;
        Category = category;
        EventId = eventId;
        Exception = exception;
    }
}