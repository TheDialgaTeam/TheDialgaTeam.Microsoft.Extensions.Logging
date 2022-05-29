namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateArgs
{
    public delegate string LoggerTemplateDelegate(in LoggerTemplateEntry logEntry);

    public LoggerTemplateDelegate? Prefix { get; set; }

    public LoggerTemplateDelegate? Suffix { get; set; }

    public LoggerTemplateArgs SetPrefix(LoggerTemplateDelegate? func)
    {
        Prefix = func;
        return this;
    }

    public LoggerTemplateArgs SetSuffix(LoggerTemplateDelegate? func)
    {
        Suffix = func;
        return this;
    }
}