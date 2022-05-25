using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public static class LoggerTemplateExtensions
{
    [RequiresUnreferencedCode("LoggerTemplateFormatterOptions's dependent types may have their members trimmed. Ensure all required members are preserved.")]
    public static ILoggingBuilder AddLoggerTemplateFormatter(this ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.AddConsoleFormatter<LoggerTemplateFormatter, LoggerTemplateFormatterOptions>();
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggerTemplateFormatter.FormatterName);
        return loggingBuilder;
    }

    [RequiresUnreferencedCode("LoggerTemplateFormatterOptions's dependent types may have their members trimmed. Ensure all required members are preserved.")]
    public static ILoggingBuilder AddLoggerTemplateFormatter(this ILoggingBuilder loggingBuilder, Action<LoggerTemplateFormatterOptions> options)
    {
        loggingBuilder.AddConsoleFormatter<LoggerTemplateFormatter, LoggerTemplateFormatterOptions>(options);
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggerTemplateFormatter.FormatterName);
        return loggingBuilder;
    }
}