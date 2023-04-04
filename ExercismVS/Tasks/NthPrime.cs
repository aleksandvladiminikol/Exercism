using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    private static bool IsPrime(int n)
    {
        for (var i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }
    private static IEnumerable<int> GetPrimes()
    {
        var i = 1;
        while (true)
        {
            if (IsPrime(i))
            {
                yield return i;
            }
            i++;
        }
    }

    public static int Prime(int nth)
    {
        if (nth is <= 0 or >= int.MaxValue)
            throw new ArgumentOutOfRangeException();
        return GetPrimes().ElementAt(nth);
    }
}