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

    public LoggerTemplate SetGlobal(Action<LoggerTemplateArgs> action)
    {
        action(Global);
        return this;
    }

    public LoggerTemplate SetTrace(Action<LoggerTemplateArgs> action)
    {
        action(Trace);
        return this;
    }

    public LoggerTemplate SetDebug(Action<LoggerTemplateArgs> action)
    {
        action(Debug);
        return this;
    }

    public LoggerTemplate SetInformation(Action<LoggerTemplateArgs> action)
    {
        action(Information);
        return this;
    }

    public LoggerTemplate SetWarning(Action<LoggerTemplateArgs> action)
    {
        action(Warning);
        return this;
    }

    public LoggerTemplate SetError(Action<LoggerTemplateArgs> action)
    {
        action(Error);
        return this;
    }

    public LoggerTemplate SetCritical(Action<LoggerTemplateArgs> action)
    {
        action(Critical);
        return this;
    }

    internal LoggerTemplateArgs.LoggerTemplateDelegate? GetPrefix(LogLevel logLevel)
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

    internal LoggerTemplateArgs.LoggerTemplateDelegate? GetSuffix(LogLevel logLevel)
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