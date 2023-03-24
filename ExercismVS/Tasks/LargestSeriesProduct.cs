using System;
using System.Linq;
using System.Collections.Generic;
public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (digits.Any(_ => !char.IsNumber(_)) || span < 0 || span > digits.Length)
            throw new ArgumentException();
        
        return Enumerable
            .Range(0, digits.Length - span + 1)
            .Select(i => digits.Substring(i, span))
            .Select(_ => _
                .Select(_ => (int) char.GetNumericValue(_))
                .Aggregate(1, (i, d) => i * d))
            .Max();
    }
}