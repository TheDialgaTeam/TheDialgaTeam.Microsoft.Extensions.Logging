namespace TheDialgaTeam.Core.Logging.Microsoft.LoggerTemplate;

public class LogLevelFormattingBuilder
{
    internal readonly LogLevelFormatting LogLevelFormatting = new();

    public LogLevelFormattingBuilder SetGlobal(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Global = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetTrace(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Trace = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetDebug(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Debug = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetInformation(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Information = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetWarning(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Warning = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetError(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Error = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetCritical(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder();
        action(builder);
        LogLevelFormatting.Critical = builder.MessageFormatting;
        return this;
    }
}