namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateArgs
{
    public delegate string LoggerTemplate(in LogEntry logEntry);

    public LoggerTemplate? Prefix { get; set; }

    public LoggerTemplate? Suffix { get; set; }
}