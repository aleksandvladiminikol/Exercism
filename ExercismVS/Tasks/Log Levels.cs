using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercism
{
    internal static class LogLine
    {
        public static string Message(string Log)
        {
            Match operands = Regex.Match(Log, @"[^(\:)]*$", RegexOptions.None);
            string result = operands.Groups[0].Value.Trim();
            result.Replace("\n\v", "");
            result.Replace("\v\n", "");
            result.Replace("\n", "");
            result.Replace("\v", "");
            return result;
        }
        public static string LogLevel(string Log)
        {
            Match operands = Regex.Match(Log, @"(?<=\[)(.*?)(?=\])", RegexOptions.None);
            return operands.Groups[0].Value.Trim().ToLower();

        }
        public static string Reformat(string Log)
        {
            string message = Message(Log);
            string level = LogLevel(Log);
            string result = message + " (" + level + ")";
            return result;
        }
    }
}
