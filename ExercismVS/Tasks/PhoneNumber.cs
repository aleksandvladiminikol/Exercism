using System;
using System.Linq;
using System.Collections.Generic;

public class PhoneNumber
{
    private const string Format = "NXXNXXXXXX";
    private const char NChar = 'N';
    private const int MinN = 2;
    
    public static string Clean(string phoneNumber)
    {
        var processed = phoneNumber.Where(char.IsDigit).Select(char.GetNumericValue).ToList();

        if (processed.Count > Format.Length + 1)
            throw new ArgumentException();
        
        while (processed.Count > Format.Length)
        {
            if (processed[0] != 1)
                throw new ArgumentException();
            processed.RemoveAt(0);
        }

        var checkingIndexes = 
            from pair in Format.Select((c, i) => (c, i)) 
            where pair.c == NChar 
            select pair.i;
        
        if (checkingIndexes.Any(checkIndex => processed[checkIndex] < MinN) || processed.Count() < Format.Length)
        {
            throw new ArgumentException();
        }
        return string.Concat(processed);

    }
}