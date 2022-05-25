using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public readonly struct LogEntry
{
    public LogLevel LogLevel { get; }

    public string Category { get; }

    public EventId EventId { get; }

    public Exception? Exception { get; }

    public LogEntry(LogLevel logLevel, string category, EventId eventId, Exception? exception)
    {
        LogLevel = logLevel;
        Category = category;
        EventId = eventId;
        Exception = exception;
    }
}