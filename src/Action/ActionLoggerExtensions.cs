using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Microsoft.Extensions.Logging.Action;

public static class ActionLoggerExtensions
{
    public static ILoggingBuilder AddActionLogger(this ILoggingBuilder loggingBuilder, Action<string> actionLogger)
    {
        loggingBuilder.Services.AddOptions<LoggingTemplateFormatterOptions>();
        loggingBuilder.Services.TryAddSingleton<LoggingTemplateFormatter>();
        loggingBuilder.Services.TryAddSingleton<ActionLoggerConfiguration>();
        loggingBuilder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ActionLoggerProvider>());
        return loggingBuilder;
    }
    
    public static ILoggingBuilder AddActionLogger(this ILoggingBuilder loggingBuilder, Action<LoggingTemplateFormatterOptions> options)
    {
        loggingBuilder.Services.AddOptions<LoggingTemplateFormatterOptions>().Configure(options);
        loggingBuilder.Services.TryAddSingleton<LoggingTemplateFormatter>();
        loggingBuilder.Services.TryAddSingleton<ActionLoggerConfiguration>();
        loggingBuilder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ActionLoggerProvider>());
        return loggingBuilder;
    }
}