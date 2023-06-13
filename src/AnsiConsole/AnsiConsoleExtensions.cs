using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Microsoft.Extensions.Logging.AnsiConsole;

public static partial class AnsiConsoleExtensions
{
    private static partial class Native
    {
        public const int StandardOutputHandleId = -11;
        public const int EnableVirtualTerminalProcessingMode = 4;
        public const int InvalidHandleValue = -1;
        
        [LibraryImport("kernel32.dll")]
        public static partial IntPtr GetStdHandle(int handleId);

        [LibraryImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool GetConsoleMode(IntPtr handle, out int mode);

        [LibraryImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetConsoleMode(IntPtr handle, int mode);
    }
    
    public static ILoggingBuilder AddAnsiConsole(this ILoggingBuilder loggingBuilder)
    {
        SetAnsiConsole();
        loggingBuilder.AddConsoleFormatter<LoggingTemplateFormatter, LoggingTemplateFormatterOptions>();
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggingTemplateFormatter.FormatterName);
        return loggingBuilder;
    }
    
    public static ILoggingBuilder AddAnsiConsole(this ILoggingBuilder loggingBuilder, Action<LoggingTemplateFormatterOptions> options)
    {
        SetAnsiConsole();
        loggingBuilder.AddConsoleFormatter<LoggingTemplateFormatter, LoggingTemplateFormatterOptions>(options);
        loggingBuilder.AddConsole(loggerOptions => loggerOptions.FormatterName = LoggingTemplateFormatter.FormatterName);
        return loggingBuilder;
    }

    private static void SetAnsiConsole()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
        
        var stdout = Native.GetStdHandle(Native.StandardOutputHandleId);

        if (stdout != Native.InvalidHandleValue && Native.GetConsoleMode(stdout, out var mode))
        {
            Native.SetConsoleMode(stdout, mode | Native.EnableVirtualTerminalProcessingMode);
        }
    }
}