namespace TheDialgaTeam.Microsoft.Extensions.Logging.LoggingTemplate;

public sealed class MessageFormattingBuilder
{
    internal readonly MessageFormatting MessageFormatting;

    internal MessageFormattingBuilder(MessageFormatting messageFormatting)
    {
        MessageFormatting = messageFormatting;
    }
    
    public MessageFormattingBuilder SetPrefix(string template)
    {
        MessageFormatting.Prefix = (in LoggingTemplateEntry _) => template;
        return this;
    }

    public MessageFormattingBuilder SetPrefix(MessageTemplate? messageTemplate)
    {
        MessageFormatting.Prefix = messageTemplate;
        return this;
    }
    
    public MessageFormattingBuilder SetSuffix(string template)
    {
        MessageFormatting.Suffix = (in LoggingTemplateEntry _) => template;
        return this;
    }
    
    public MessageFormattingBuilder SetSuffix(MessageTemplate? messageTemplate)
    {
        MessageFormatting.Suffix = messageTemplate;
        return this;
    }
}