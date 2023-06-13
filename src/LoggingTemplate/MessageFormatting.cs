namespace TheDialgaTeam.Microsoft.Extensions.Logging.LoggingTemplate;

public delegate string MessageTemplate(in LoggingTemplateEntry logEntry);

internal sealed class MessageFormatting
{
    public static MessageFormatting DefaultMessageFormatting => new() { Prefix = DefaultMessageTemplate, Suffix = EmptyMessageTemplate };
    public static MessageFormatting EmptyMessageFormatting => new() { Prefix = EmptyMessageTemplate, Suffix = EmptyMessageTemplate };

    public MessageTemplate? Prefix { get; set; }

    public MessageTemplate? Suffix { get; set; }

    private static string DefaultMessageTemplate(in LoggingTemplateEntry _)
    {
        return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} ";
    }

    private static string EmptyMessageTemplate(in LoggingTemplateEntry _)
    {
        return string.Empty;
    }
}