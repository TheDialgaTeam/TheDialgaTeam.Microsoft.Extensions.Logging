using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Microsoft.Extensions.Logging;

public readonly record struct LoggingTemplateEntry(LogLevel LogLevel, string Category, EventId EventId, Exception? Exception);