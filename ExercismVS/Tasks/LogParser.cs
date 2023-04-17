using System;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        var pattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]*";
        var res = Regex.Match(text, pattern);
        return res.Length > 0;
    }

    public string[] SplitLogLine(string text)
    {
        string pattern = @"<[\^*=~-]*>";
        return Regex.Split(text, pattern);
    }

    public int CountQuotedPasswords(string lines) {
        string pattern = "\"[^\"]*password[^\"]*\"";
        MatchCollection matches = Regex.Matches(lines, pattern, RegexOptions.IgnoreCase);
        return matches.Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        string pattern = @"(end-of-line[\d]{2,})";
        return Regex.Replace(line, pattern, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var result = new string[lines.Length];
        var index = 0;
        foreach (var line in lines) {
            var match = Regex.Match(line, @"(password[^\s]+)", RegexOptions.IgnoreCase);
            if (match.Success) {
                result[index] = $"{match.Value}: {line}";
            } else {
                result[index] = $"--------: {line}";
            }

            index++;
        }

        return result;
    }
}