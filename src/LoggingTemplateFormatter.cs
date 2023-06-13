using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace TheDialgaTeam.Microsoft.Extensions.Logging;

public sealed class LoggingTemplateFormatter : ConsoleFormatter, IDisposable
{
    public const string FormatterName = "LoggingTemplate";

    private readonly IDisposable? _optionsReloadToken;
    private LoggingTemplateFormatterOptions _formatterOptions;

    public LoggingTemplateFormatter(IOptionsMonitor<LoggingTemplateFormatterOptions> options) : base(FormatterName)
    {
        _formatterOptions = options.CurrentValue;
        _optionsReloadToken = options.OnChange(formatterOptions => _formatterOptions = formatterOptions);
    }

    public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter)
    {
        var message = logEntry.Formatter.Invoke(logEntry.State, logEntry.Exception);
        if (logEntry.Exception == null) return;

        var loggerTemplateEntry = new LoggingTemplateEntry(logEntry.LogLevel, logEntry.Category, logEntry.EventId, logEntry.Exception);

        textWriter.Write(_formatterOptions.GetPrefix(loggerTemplateEntry).Invoke(loggerTemplateEntry));
        textWriter.Write(message);
        textWriter.Write(_formatterOptions.GetSuffix(loggerTemplateEntry).Invoke(loggerTemplateEntry));
        textWriter.Write(Environment.NewLine);

        if (logEntry.Exception != null)
        {
            textWriter.WriteLine(logEntry.Exception.ToString());
        }
    }

    public void Dispose()
    {
        _optionsReloadToken?.Dispose();
    }
}