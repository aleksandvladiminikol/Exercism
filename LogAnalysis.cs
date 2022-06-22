namespace Exercism;

using System;
using System.Text.RegularExpressions;
using System.Text;

public static class LogAnalysis 
{
    public static string SubstringAfter(string split)
    {
        var log = "[INFO]: File Deleted.";
        var result = log.Split(split);
        return result[1];
    }
    public static string SubstringBetween(string begin, string end)
    {
        string log = "[INFO]: File Deleted.";
        string pattern = @"(?<=\BEGIN)(.*?)(?=\END)".Replace("BEGIN", begin).Replace("END", end); 
        Match operands = Regex.Match(log, pattern, RegexOptions.None);
        return operands.Groups[0].Value.Trim();
    }
    public static string Message()
    {
        var log = "[ERROR]: Missing ; on line 20.";
        Match operands = Regex.Match(log, @"[^(\:)]*$", RegexOptions.None);
        string result = operands.Groups[0].Value.Trim();
        result.Replace("\n\v", "");
        result.Replace("\v\n", "");
        result.Replace("\n", "");
        result.Replace("\v", "");
        return result;; 
    }
    public static string LogLevel()
    {
        var log = "[ERROR]: Missing ; on line 20.";
        Match operands = Regex.Match(log, @"(?<=\[)(.*?)(?=\])", RegexOptions.None);
        return operands.Groups[0].Value.Trim();

    }
}