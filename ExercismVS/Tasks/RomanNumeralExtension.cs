using System.Text;

namespace Exercism;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        var thousands = (value - value % 1000);
        var hundreds = (value - thousands - value % 100);
        var tens = (value - thousands - hundreds - value % 10);
        var units = (value - thousands - hundreds - tens);

        var result = new StringBuilder();

        result.Append(GetRomanNumber(thousands, 1000, "M"));
        result.Append(GetRomanNumber(hundreds, 100, "C", "D", "M"));
        result.Append(GetRomanNumber(tens, 10, "X", "L", "C"));
        result.Append(GetRomanNumber(units, 1, "I", "V", "X"));
        
        return result.ToString();

    }

    public static string GetRomanNumber(int number, int divider, string mainSymbol, string halfCountSymbol = "",
        string parentSymbol = "")
    {
        var result = new StringBuilder();
        var count = number / divider;

        if (count <= 3)
        {
            for (int i = 0; i < count; i++)
            {
                result.Append(mainSymbol);
            }
        }
        else if (count > 3 && count <= 5)
        {
            for (int i = count; i < 5 ; i++)
            {
                result.Append(mainSymbol);
            }

            result.Append(halfCountSymbol);
        }
        else if (count > 5 && count <= 8)
        {
            result.Append(halfCountSymbol);
            for (int i = 5; i < count; i++)
            {
                result.Append(mainSymbol);
            }
        }
        else
        {
            for (int i = count; i < 10; i++)
            {
                result.Append(mainSymbol);
            }

            result.Append(parentSymbol);
        }

        return result.ToString();

    }

}