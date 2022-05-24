using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateFormatterOptions : ConsoleFormatterOptions
{
    public LoggerTemplateArgs Trace { get; } = new();

    public LoggerTemplateArgs Debug { get; } = new();

    public LoggerTemplateArgs Information { get; } = new();

    public LoggerTemplateArgs Warning { get; } = new();

    public LoggerTemplateArgs Error { get; } = new();

    public LoggerTemplateArgs Critical { get; } = new();

    public LoggerTemplateArgs Global { get; } = new();

    public LoggerTemplateFormatterOptions()
    {
        Global.PrefixTemplate = _ => $"{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss} ";
    }

    public Func<LogEntry, string>? GetPrefixTemplate(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => Trace.PrefixTemplate ?? Global.PrefixTemplate,
            LogLevel.Debug => Debug.PrefixTemplate ?? Global.PrefixTemplate,
            LogLevel.Information => Information.PrefixTemplate ?? Global.PrefixTemplate,
            LogLevel.Warning => Warning.PrefixTemplate ?? Global.PrefixTemplate,
            LogLevel.Error => Error.PrefixTemplate ?? Global.PrefixTemplate,
            LogLevel.Critical => Critical.PrefixTemplate ?? Global.PrefixTemplate,
            var _ => null
        };
    }

    public Func<LogEntry, string>? GetSuffixTemplate(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => Trace.SuffixTemplate ?? Global.SuffixTemplate,
            LogLevel.Debug => Debug.SuffixTemplate ?? Global.SuffixTemplate,
            LogLevel.Information => Information.SuffixTemplate ?? Global.SuffixTemplate,
            LogLevel.Warning => Warning.SuffixTemplate ?? Global.SuffixTemplate,
            LogLevel.Error => Error.SuffixTemplate ?? Global.SuffixTemplate,
            LogLevel.Critical => Critical.SuffixTemplate ?? Global.SuffixTemplate,
            var _ => null
        };
    }
}