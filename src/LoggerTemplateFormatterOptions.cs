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

    private static string GetDefaultPrefix(in LoggerTemplateEntry logEntry)
    {
        return $"{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss} ";
    }

    public LoggerTemplateFormatterOptions SetDefaultTemplate(Action<LoggerTemplate> action)
    {
        action.Invoke(DefaultTemplate);
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate(string category, Action<LoggerTemplate> action)
    {
        var temp = new LoggerTemplate();
        action(temp);
        TemplateByCategory.TryAdd(category, temp);
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate(Type type, Action<LoggerTemplate> action)
    {
        var temp = new LoggerTemplate();
        action(temp);
        TemplateByCategory.TryAdd(type.FullName!, temp);
        return this;
    }

    public LoggerTemplateFormatterOptions SetTemplate<TType>(Action<LoggerTemplate> action)
    {
        var temp = new LoggerTemplate();
        action(temp);
        TemplateByCategory.TryAdd(typeof(TType).FullName!, temp);
        return this;
    }

    internal LoggerTemplateArgs.LoggerTemplateDelegate? GetPrefix(in LoggerTemplateEntry logEntry)
    {
        return TemplateByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetPrefix(logEntry.LogLevel) : DefaultTemplate.GetPrefix(logEntry.LogLevel);
    }

    internal LoggerTemplateArgs.LoggerTemplateDelegate? GetSuffix(in LoggerTemplateEntry logEntry)
    {
        return TemplateByCategory.TryGetValue(logEntry.Category, out var template) ? template.GetSuffix(logEntry.LogLevel) : DefaultTemplate.GetSuffix(logEntry.LogLevel);
    }
}