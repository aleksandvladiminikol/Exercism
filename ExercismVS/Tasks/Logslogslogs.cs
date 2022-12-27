using System;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Exercism.Tasks;

enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    public static LogLevel GetLogLevel(string Shortname)
    {
        switch (Shortname)
        {
            case "TRC": return LogLevel.Trace;
            case "INF": return LogLevel.Info;
            case "WRN": return LogLevel.Warning;
            case "ERR": return LogLevel.Error;
            case "DBG": return LogLevel.Debug;
            case "FTL": return LogLevel.Fatal;
            default: return LogLevel.Unknown;
        }
    }
    
    public static LogLevel ParseLogLevel(string logLine)
    {
        var lvl = Regex.Match(logLine, @"(?<=\[)(.*?)(?=\])", RegexOptions.None).Value;
        return GetLogLevel(lvl);
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{((int) logLevel)}:{message}";
    }
}
