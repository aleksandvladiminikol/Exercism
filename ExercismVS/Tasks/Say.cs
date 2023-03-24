using System;
using System.Text;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections;
public static class Say
{
    private const long limit = 1000000000000;
    private readonly static Dictionary<long, string> Rules = new Dictionary<long, string>()
    {
        [0] = "zero",
        [1] = "one",
        [2] = "two",
        [3] = "three",
        [4] = "four",
        [5] = "five",
        [6] = "six",
        [7] = "seven",
        [8] = "eight",
        [9] = "nine",
        [10] = "ten",
        [11] = "eleven",
        [12] = "twelve",
        [13] = "thirteen",
        [14] = "fourteen",
        [15] = "fifteen",
        [16] = "sixteen",
        [17] = "seventeen",
        [18] = "eighteen",
        [19] = "nineteen",
        [20] = "twenty",
        [30] = "thirty",
        [40] = "forty",
        [50] = "fifty",
        [60] = "sixty",
        [70] = "seventy",
        [80] = "eighty",
        [90] = "ninety",

    };
    private readonly static Dictionary<long, string> BitRates = new Dictionary<long, string>() {
        [100] = "hundred",
        [1000] = "thousand",
        [1000000] = "million",
        [1000000000] = "billion",
        [1000000000000] = "trillion"
    };

    public static string InEnglish(long number)
    {
        if (number is < 0 or >= limit) throw new ArgumentOutOfRangeException();

        var result = new StringBuilder();
        foreach ((var birRate, var _n) in SplitToThousands(number))
        {
            BitRates.TryGetValue(birRate, out string? bitRateString);
            result.Append($"{GetNumberEnding(_n)} {bitRateString}");
            result.Append(' ');
        }
        return result.ToString().Trim();
    }

    private static string GetNumberEnding(int number)
    {
        var hundreds = number / 100;
        BitRates.TryGetValue(100, out string? hundredsName);
        Rules.TryGetValue(hundreds, out string? hundredsAmount);
        var hundredsStr = hundreds == 0 ? String.Empty : $"{hundredsAmount} {hundredsName}";
        number -= hundreds * 100;
        var ones = number % 10;
        string? result;

        if (!Rules.TryGetValue(number, out result))
        {
            Rules.TryGetValue(number - ones, out string? tensStr);
            Rules.TryGetValue(ones, out string? onesStr);
            result = $"{hundredsStr} {tensStr}-{onesStr}";
        }
        return result.Trim();
    }

    private static IDictionary<long, int> SplitToThousands(long number)
    {
        var result = new Dictionary<long, int>();
        var res = number;
        var divider = limit;
        while (divider >= 100)
        {
            var curValue = res / divider;
            if (curValue > 0) result.TryAdd(divider, (int)curValue);
            res -= curValue * divider;
            divider /= divider == 1000 ? 10 : 1000;
        }
        if (res > 0 || result.Count == 0)
            result.TryAdd(1, (int) res);
        return result;
    }
}