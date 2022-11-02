using System.Text;
using System.Text.RegularExpressions;

namespace Exercism;

using System;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        
        StringBuilder result = new();
        var res = Regex.Split(phrase.ToUpper(), " |-");
        foreach (var word in res)
        {
            var sym = GetSymbol(word);
            if (sym != char.MinValue)
            {
                result.Append(sym);
            }
        }

        return result.ToString();
    }

    public static char GetSymbol(string word)
    {
        var minUpper = 65;
        var maxUpper = 90;

        char result = Char.MinValue;
        foreach (var symbol in word)
        {
            if (symbol >= minUpper && symbol <= maxUpper)
            {
                result = symbol;
                break;
            }
        }
        return result;
    }
}