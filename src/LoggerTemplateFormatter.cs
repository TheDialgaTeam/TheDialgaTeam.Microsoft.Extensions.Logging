using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateFormatter : ConsoleFormatter, IDisposable
{
    public const string FormatterName = "LoggerTemplate";

    private readonly IDisposable _optionsReloadToken;
    private LoggerTemplateFormatterOptions? _formatterOptions;

    public LoggerTemplateFormatter(IOptionsMonitor<LoggerTemplateFormatterOptions> options) : base(FormatterName)
    {
        ReloadLoggerOptions(options.CurrentValue);
        _optionsReloadToken = options.OnChange(ReloadLoggerOptions);
    }

    public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider scopeProvider, TextWriter textWriter)
    {
        var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);
        if (logEntry.Exception == null && message == null) return;

        textWriter.Write(_formatterOptions?.GetPrefixTemplate(logEntry.LogLevel)?.Invoke(new LogEntry(logEntry.LogLevel, logEntry.Category, logEntry.EventId, logEntry.Exception)));
        textWriter.Write(message);
        textWriter.Write(_formatterOptions?.GetSuffixTemplate(logEntry.LogLevel)?.Invoke(new LogEntry(logEntry.LogLevel, logEntry.Category, logEntry.EventId, logEntry.Exception)));
        textWriter.Write(Environment.NewLine);

        if (logEntry.Exception != null)
        {
            textWriter.WriteLine(logEntry.Exception.ToString());
        }
    }

    private void ReloadLoggerOptions(LoggerTemplateFormatterOptions options)
    {
        _formatterOptions = options;
    }

    public void Dispose()
    {
        _optionsReloadToken.Dispose();
    }
}