using System;
using System.Linq;
using System.Collections;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 0) throw new ArgumentOutOfRangeException();
        var numbers = Enumerable.Range(2, limit-1);
        for (var i = 2; i <= limit; i++)
        {
            for (var j = 2; j <= limit/i; j++)
            {
                numbers = numbers.Where(_ => _ != i * j).ToArray();
            }
        }
        return numbers.ToArray();
    }
}