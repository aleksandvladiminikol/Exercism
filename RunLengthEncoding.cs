using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System;
    
namespace Exercism;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var result = new StringBuilder();

        char? prevSym = null;
        int counter = 1;
        
        foreach (var sym in input.ToList().Append(Char.MaxValue))
        {
            if (prevSym == null)
            {
                prevSym = sym;
                continue;
            }

            if (prevSym == sym)
            {
                counter++;
            }
            else
            {
                if (counter > 1)
                {
                    result.Append(counter);
                } 
                result.Append(prevSym);
                counter = 1;
                prevSym = sym;
            }
            
        }
        return result.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder result = new();
        foreach (var matches in Regex.Matches(FormatInput(input), "\\d+\\D+"))
        {
            var segment = matches.ToString();
            var count = Int32.Parse(Regex.Match(segment, "\\d+").ToString());
            var symbol = segment.ElementAt(segment.Length - 1);

            for (var i = 0; i < count; i++)
            {
                result.Append(symbol);
            }

        }
        return result.ToString();
    }

    public static string FormatInput(string input)
    {
        var processedInput = new StringBuilder();
        bool appendCount = true;
        foreach (var sym in input)
        {
            if (char.IsDigit(sym))
            {
                appendCount = false;
                processedInput.Append(sym);
            }
            else
            {
                if (appendCount)
                {
                    processedInput.Append(1);
                }
                processedInput.Append(sym);
                appendCount = true;
            }
        }
        return processedInput.ToString();
    }
}
