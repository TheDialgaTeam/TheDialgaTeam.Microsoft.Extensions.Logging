namespace TheDialgaTeam.Core.Logging.Microsoft.LoggerTemplate;

public class MessageFormattingBuilder
{
    internal readonly MessageFormatting MessageFormatting;

    internal MessageFormattingBuilder(MessageFormatting messageFormatting)
    {
        MessageFormatting = messageFormatting;
    }
    
    public MessageFormattingBuilder SetPrefix(string template)
    {
        MessageFormatting.Prefix = (in LoggerTemplateEntry _) => template;
        return this;
    }

    public MessageFormattingBuilder SetPrefix(MessageTemplate? messageTemplate)
    {
        MessageFormatting.Prefix = messageTemplate;
        return this;
    }
    
    public MessageFormattingBuilder SetSuffix(string template)
    {
        MessageFormatting.Suffix = (in LoggerTemplateEntry _) => template;
        return this;
    }
    
    public MessageFormattingBuilder SetSuffix(MessageTemplate? messageTemplate)
    {
        MessageFormatting.Suffix = messageTemplate;
        return this;
    }
}