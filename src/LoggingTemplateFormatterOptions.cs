using Microsoft.Extensions.Logging.Console;
using TheDialgaTeam.Microsoft.Extensions.Logging.LoggingTemplate;

namespace TheDialgaTeam.Microsoft.Extensions.Logging;

public sealed class LoggingTemplateFormatterOptions : ConsoleFormatterOptions
{
    private LogLevelFormatting _defaultLogLevelFormatting = new();
    private readonly Dictionary<string, LogLevelFormatting> _logLevelFormattingByCategory = new();

    public LoggingTemplateFormatterOptions SetDefaultTemplate(Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _defaultLogLevelFormatting = builder.LogLevelFormatting;
        return this;
    }

    public LoggingTemplateFormatterOptions SetTemplate(string category, Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _logLevelFormattingByCategory[category] = builder.LogLevelFormatting;
        return this;
    }

    public LoggingTemplateFormatterOptions SetTemplate(Type type, Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _logLevelFormattingByCategory[type.FullName!] = builder.LogLevelFormatting;
        return this;
    }

    public LoggingTemplateFormatterOptions SetTemplate<TCategory>(Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _logLevelFormattingByCategory[typeof(TCategory).FullName!] = builder.LogLevelFormatting;
        return this;
    }

    internal MessageTemplate GetPrefix(in LoggingTemplateEntry logEntry)
    {
        return _logLevelFormattingByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetPrefix(logEntry.LogLevel) : _defaultLogLevelFormatting.GetPrefix(logEntry.LogLevel);
    }

    internal MessageTemplate GetSuffix(in LoggingTemplateEntry logEntry)
    {
        return _logLevelFormattingByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetSuffix(logEntry.LogLevel) : _defaultLogLevelFormatting.GetSuffix(logEntry.LogLevel);
    }
}