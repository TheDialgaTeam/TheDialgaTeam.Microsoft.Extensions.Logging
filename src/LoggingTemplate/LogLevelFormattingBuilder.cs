namespace TheDialgaTeam.Microsoft.Extensions.Logging.LoggingTemplate;

public sealed class LogLevelFormattingBuilder
{
    internal readonly LogLevelFormatting LogLevelFormatting = new();

    public LogLevelFormattingBuilder SetGlobal(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Global);
        action(builder);
        LogLevelFormatting.Global = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetTrace(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Trace ?? MessageFormatting.EmptyMessageFormatting);
        action(builder);
        LogLevelFormatting.Trace = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetDebug(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Debug ?? MessageFormatting.EmptyMessageFormatting);
        action(builder);
        LogLevelFormatting.Debug = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetInformation(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Information ?? MessageFormatting.EmptyMessageFormatting);
        action(builder);
        LogLevelFormatting.Information = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetWarning(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Warning ?? MessageFormatting.EmptyMessageFormatting);
        action(builder);
        LogLevelFormatting.Warning = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetError(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Error ?? MessageFormatting.EmptyMessageFormatting);
        action(builder);
        LogLevelFormatting.Error = builder.MessageFormatting;
        return this;
    }
    
    public LogLevelFormattingBuilder SetCritical(Action<MessageFormattingBuilder> action)
    {
        var builder = new MessageFormattingBuilder(LogLevelFormatting.Critical ?? MessageFormatting.EmptyMessageFormatting);
        action(builder);
        LogLevelFormatting.Critical = builder.MessageFormatting;
        return this;
    }
}