using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public static class LoggerTemplateExtensions
{
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode")]
    public static ILoggingBuilder AddLoggerTemplateFormatter(this ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.AddConsoleFormatter<LoggerTemplateFormatter, LoggerTemplateFormatterOptions>();
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggerTemplateFormatter.FormatterName);
        return loggingBuilder;
    }

    [UnconditionalSuppressMessage("AssemblyLoadTrimming", "IL2026:RequiresUnreferencedCode")]
    public static ILoggingBuilder AddLoggerTemplateFormatter(this ILoggingBuilder loggingBuilder, Action<LoggerTemplateFormatterOptions> options)
    {
        loggingBuilder.AddConsoleFormatter<LoggerTemplateFormatter, LoggerTemplateFormatterOptions>(options);
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggerTemplateFormatter.FormatterName);
        return loggingBuilder;
    }
}