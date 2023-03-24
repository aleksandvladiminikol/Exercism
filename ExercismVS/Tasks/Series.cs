using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length < sliceLength || sliceLength <= 0 || numbers == string.Empty)
            throw new ArgumentException();
        var slices = new List<string>();
        var start = 0;
        var end = sliceLength;
        while (end <= numbers.Length)
        {
            slices.Add(new StringBuilder().AppendJoin("", numbers.Where(((c, i) => i >= start && i <= end - 1)).ToArray()).ToString());
            start++;
            end++;
        }

        return slices.ToArray();
    }
}