using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Core.Logging.Microsoft;

public static class LoggerTemplateExtensions
{
    private static class Native
    {
        public const int StandardOutputHandleId = -11;
        public const int EnableVirtualTerminalProcessingMode = 4;
        public const int InvalidHandleValue = -1;
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handleId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr handle, int mode);
    }
    
    public static ILoggingBuilder AddLoggerTemplateFormatter(this ILoggingBuilder loggingBuilder)
    {
        SetAnsiConsole();
        loggingBuilder.AddConsoleFormatter<LoggerTemplateFormatter, LoggerTemplateFormatterOptions>();
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggerTemplateFormatter.FormatterName);
        return loggingBuilder;
    }
    
    public static ILoggingBuilder AddLoggerTemplateFormatter(this ILoggingBuilder loggingBuilder, Action<LoggerTemplateFormatterOptions> options)
    {
        SetAnsiConsole();
        loggingBuilder.AddConsoleFormatter<LoggerTemplateFormatter, LoggerTemplateFormatterOptions>(options);
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggerTemplateFormatter.FormatterName);
        return loggingBuilder;
    }

    private static void SetAnsiConsole()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
        
        var stdout = Native.GetStdHandle(Native.StandardOutputHandleId);

        if (stdout != (IntPtr) Native.InvalidHandleValue && Native.GetConsoleMode(stdout, out var mode))
        {
            Native.SetConsoleMode(stdout, mode | Native.EnableVirtualTerminalProcessingMode);
        }
    }
}