namespace Exercism;

using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var currentValue = number;
        var divider = 2;

        var result = new List<long>();
        
        while (divider <= currentValue)
        {
            if (currentValue % divider != 0)
            {
                divider++;
                continue;
            }

            result.Add(divider);
            currentValue = currentValue / divider;
        }
        
        return result.ToArray();

    }
    
    
}