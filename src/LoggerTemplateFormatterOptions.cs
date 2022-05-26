using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging.Console;

namespace TheDialgaTeam.Core.Logging.Microsoft;

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
public class LoggerTemplateFormatterOptions : ConsoleFormatterOptions
{
    public LoggerTemplate DefaultTemplate { get; } = new();

    public Dictionary<string, LoggerTemplate> TemplateByCategory { get; } = new();

    public LoggerTemplateFormatterOptions()
    {
        DefaultTemplate.Global.Prefix = GetDefaultPrefix;
    }

    private static string GetDefaultPrefix(in LogEntry logEntry)
    {
        return $"{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss} ";
    }

    public LoggerTemplateFormatterOptions SetDefaultTemplate(Action<LoggerTemplate> action)
    {
        action.Invoke(DefaultTemplate);
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate(Type type, LoggerTemplate loggerTemplate)
    {
        TemplateByCategory.TryAdd(type.FullName!, loggerTemplate);
        return this;
    }

    public LoggerTemplateArgs.LoggerTemplate? GetPrefix(in LogEntry logEntry)
    {
        return TemplateByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetPrefix(logEntry.LogLevel) : DefaultTemplate.GetPrefix(logEntry.LogLevel);
    }

    public LoggerTemplateArgs.LoggerTemplate? GetSuffix(in LogEntry logEntry)
    {
        return TemplateByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetSuffix(logEntry.LogLevel) : DefaultTemplate.GetSuffix(logEntry.LogLevel);
    }
}