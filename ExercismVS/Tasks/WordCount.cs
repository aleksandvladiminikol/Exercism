using System;
using System.Collections.Generic;
using System.Linq;
public static class WordCount
{
    private const char WhiteSpace = ' ';
    private const char Apostrophe = '\'';

    public static IDictionary<string, int> CountWords(string phrase)
    {
        return string
            .Concat(phrase
                .ToLower()
                .Select(_ => 
                    (char.IsLetterOrDigit(_) || char.IsWhiteSpace(_) || _ == Apostrophe) 
                    && !char.IsControl(_) 
                    && !char.IsSeparator(_) 
                    && !(char.IsPunctuation(_) && _ != Apostrophe) ? _ : WhiteSpace)
                .ToArray())
            .Split(WhiteSpace, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => string
                .Concat(s
                    .Where((c, i) =>
                        !char.IsPunctuation(c) 
                        || (char.IsPunctuation(c) && !(i == 0 || i == s.Length - 1)))
                    .ToArray()))
            .Where(s => s.Length > 0)
            .GroupBy(s => s)
            .ToDictionary(grp => grp.Key, grp => grp.Count());
    }
}