using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Microsoft.Extensions.Logging.Action;

[ProviderAlias("Action")]
public sealed class ActionLoggerProvider : ILoggerProvider
{
    private readonly ActionLoggerConfiguration _configuration;
    private readonly LoggingTemplateFormatter _formatter;
    private readonly ConcurrentDictionary<string, ActionLogger> _loggers = new();

    public ActionLoggerProvider(ActionLoggerConfiguration configuration, LoggingTemplateFormatter formatter)
    {
        _configuration = configuration;
        _formatter = formatter;
    }
    
    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.TryGetValue(categoryName, out var logger) ? logger : _loggers.GetOrAdd(categoryName, new ActionLogger(categoryName, _formatter, _configuration));
    }
    
    public void Dispose()
    {
    }
}