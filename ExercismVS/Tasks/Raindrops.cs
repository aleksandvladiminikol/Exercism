using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public static class Raindrops
{
    private static readonly Dictionary<int, string> Rules = new()
    {
        [3] = "Pling",
        [5] = "Plang",
        [7] = "Plong",
    };

    public static string Convert(int number)
    {
        var res = string.Concat(from rule in Rules where number % rule.Key == 0 select rule.Value);
        return res.Length == 0 ? number.ToString() : res;
    }
}