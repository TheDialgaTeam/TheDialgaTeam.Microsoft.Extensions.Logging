namespace TheDialgaTeam.Core.Logging.Microsoft;

public class LoggerTemplateArgs
{
    public Func<LogEntry, string>? PrefixTemplate { get; set; }

    public Func<LogEntry, string>? SuffixTemplate { get; set; }
}