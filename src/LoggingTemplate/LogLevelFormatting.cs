using Microsoft.Extensions.Logging;

namespace TheDialgaTeam.Microsoft.Extensions.Logging.LoggingTemplate;

internal sealed class LogLevelFormatting
{
    public MessageFormatting Global { get; set; } = MessageFormatting.DefaultMessageFormatting;

    public MessageFormatting? Trace { get; set; }

    public MessageFormatting? Debug { get; set; }

    public MessageFormatting? Information { get; set; }

    public MessageFormatting? Warning { get; set; }

    public MessageFormatting? Error { get; set; }

    public MessageFormatting? Critical { get; set; }

    public MessageTemplate GetPrefix(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => Trace?.Prefix ?? Global.Prefix!,
            LogLevel.Debug => Debug?.Prefix ?? Global.Prefix!,
            LogLevel.Information => Information?.Prefix ?? Global.Prefix!,
            LogLevel.Warning => Warning?.Prefix ?? Global.Prefix!,
            LogLevel.Error => Error?.Prefix ?? Global.Prefix!,
            LogLevel.Critical => Critical?.Prefix ?? Global.Prefix!,
            LogLevel.None => MessageFormatting.EmptyMessageFormatting.Prefix!,
            var _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
        };
    }

    public MessageTemplate GetSuffix(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => Trace?.Suffix ?? Global.Suffix!,
            LogLevel.Debug => Debug?.Suffix ?? Global.Suffix!,
            LogLevel.Information => Information?.Suffix ?? Global.Suffix!,
            LogLevel.Warning => Warning?.Suffix ?? Global.Suffix!,
            LogLevel.Error => Error?.Suffix ?? Global.Suffix!,
            LogLevel.Critical => Critical?.Suffix ?? Global.Suffix!,
            LogLevel.None => MessageFormatting.EmptyMessageFormatting.Suffix!,
            var _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
        };
    }
}