using System.Collections;

namespace Exercism;


using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class AtbashCipher
{
    private static readonly List<char> _plain = "0123456789abcdefghijklmnopqrstuvwxyz9876543210".ToList();
    
    private static readonly int _maxIndex = _plain.Count - 1;
    private const char WhiteSpace = ' ';
    public static string Encode(string plainValue)
    {
        var result = new StringBuilder();
        var counter = 0;
        foreach (var sym in plainValue.ToLower())
        {
            var index = _plain.LastIndexOf(sym);
            if (index > -1)
                result.Append(_plain[_maxIndex - index]);
            else
                continue;
            counter++;
            if (counter % 5 == 0)
                result.Append(WhiteSpace);
        }
        return result.ToString().TrimEnd();
    }

    public static string Decode(string encodedValue)
    {
        var result = new StringBuilder();
        foreach (var sym in encodedValue.ToLower())
        {
            var index = _plain.LastIndexOf(sym);
            if (index > -1)
                result.Append(_plain[_maxIndex - index]);
        }
        return result.ToString();
    }
}