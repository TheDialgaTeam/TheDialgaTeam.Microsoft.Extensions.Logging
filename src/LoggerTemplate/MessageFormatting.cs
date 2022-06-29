namespace TheDialgaTeam.Core.Logging.Microsoft.LoggerTemplate;

public delegate string MessageTemplate(in LoggerTemplateEntry logEntry);

internal class MessageFormatting
{
    public static MessageFormatting DefaultMessageFormatting { get; } = new() { Prefix = DefaultMessageTemplate, Suffix = EmptyMessageTemplate };

    public static MessageFormatting EmptyMessageFormatting { get; } = new() { Prefix = EmptyMessageTemplate, Suffix = EmptyMessageTemplate };

    public MessageTemplate? Prefix { get; set; }

    public MessageTemplate? Suffix { get; set; }

    private static string DefaultMessageTemplate(in LoggerTemplateEntry _)
    {
        return $"{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss} ";
    }

    private static string EmptyMessageTemplate(in LoggerTemplateEntry _)
    {
        return string.Empty;
    }
}