using System;
using System.Linq;
public static class Luhn
{
    private static int ProcessDigits(char c, int i)
    {
        var numericChar = (int) char.GetNumericValue(c);
        
        if ((i + 1) % 2 != 0) return numericChar;
        
        numericChar *= 2;
        if (numericChar > 9)
            numericChar -= 9;

        return numericChar;
    }
        
    public static bool IsValid(string number)
    {
        if (number.Any(c => !(char.IsWhiteSpace(c) || char.IsNumber(c)))) 
            return false;
        var processedNumber = string.Concat(number.Split(' ', StringSplitOptions.TrimEntries)).Where(char.IsNumber);
        
        return processedNumber.Count() > 1 &&
               processedNumber.Reverse().Select(ProcessDigits).Sum() % 10 == 0;
    }
}