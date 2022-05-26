using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplate
{
    public LoggerTemplateArgs Global { get; } = new();

    public LoggerTemplateArgs Trace { get; } = new();

    public LoggerTemplateArgs Debug { get; } = new();

    public LoggerTemplateArgs Information { get; } = new();

    public LoggerTemplateArgs Warning { get; } = new();

    public LoggerTemplateArgs Error { get; } = new();

    public LoggerTemplateArgs Critical { get; } = new();

    public LoggerTemplateArgs.LoggerTemplate? GetPrefix(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => Trace.Prefix ?? Global.Prefix,
            LogLevel.Debug => Debug.Prefix ?? Global.Prefix,
            LogLevel.Information => Information.Prefix ?? Global.Prefix,
            LogLevel.Warning => Warning.Prefix ?? Global.Prefix,
            LogLevel.Error => Error.Prefix ?? Global.Prefix,
            LogLevel.Critical => Critical.Prefix ?? Global.Prefix,
            var _ => null
        };
    }

    public LoggerTemplateArgs.LoggerTemplate? GetSuffix(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => Trace.Suffix ?? Global.Suffix,
            LogLevel.Debug => Debug.Suffix ?? Global.Suffix,
            LogLevel.Information => Information.Suffix ?? Global.Suffix,
            LogLevel.Warning => Warning.Suffix ?? Global.Suffix,
            LogLevel.Error => Error.Suffix ?? Global.Suffix,
            LogLevel.Critical => Critical.Suffix ?? Global.Suffix,
            var _ => null
        };
    }
}