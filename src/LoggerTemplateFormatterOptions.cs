using Microsoft.Extensions.Logging.Console;
using TheDialgaTeam.Core.Logging.Microsoft.LoggerTemplate;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateFormatterOptions : ConsoleFormatterOptions
{
    private LogLevelFormatting _defaultLogLevelFormatting = new();
    private readonly Dictionary<string, LogLevelFormatting> _logLevelFormattingByCategory = new();

    public LoggerTemplateFormatterOptions SetDefaultTemplate(Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _defaultLogLevelFormatting = builder.LogLevelFormatting;
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate(string category, Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _logLevelFormattingByCategory[category] = builder.LogLevelFormatting;
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate(Type type, Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _logLevelFormattingByCategory[type.FullName!] = builder.LogLevelFormatting;
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate<TCategory>(Action<LogLevelFormattingBuilder> action)
    {
        var builder = new LogLevelFormattingBuilder();
        action(builder);
        _logLevelFormattingByCategory[typeof(TCategory).FullName!] = builder.LogLevelFormatting;
        return this;
    }

    internal MessageTemplate GetPrefix(in LoggerTemplateEntry logEntry)
    {
        return _logLevelFormattingByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetPrefix(logEntry.LogLevel) : _defaultLogLevelFormatting.GetPrefix(logEntry.LogLevel);
    }

    internal MessageTemplate GetSuffix(in LoggerTemplateEntry logEntry)
    {
        return _logLevelFormattingByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetSuffix(logEntry.LogLevel) : _defaultLogLevelFormatting.GetSuffix(logEntry.LogLevel);
    }
}