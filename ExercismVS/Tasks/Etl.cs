using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();
        foreach (var pair in old)
        {
            foreach (var value in pair.Value)
            {
                result.Add(value.ToLower(), pair.Key);
            }
        }

        return result;
    }
}