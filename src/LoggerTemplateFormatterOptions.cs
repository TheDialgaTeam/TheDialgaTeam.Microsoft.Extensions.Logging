using Microsoft.Extensions.Logging.Console;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateFormatterOptions : ConsoleFormatterOptions
{
    public LoggerTemplate DefaultTemplate { get; set; } = new();

    public Dictionary<string, LoggerTemplate> TemplateByCategory { get; set; } = new();

    public LoggerTemplateFormatterOptions()
    {
        DefaultTemplate.Global.Prefix = GetDefaultPrefix;
    }

    private static string GetDefaultPrefix(in LogEntry logEntry)
    {
        return $"{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss} ";
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