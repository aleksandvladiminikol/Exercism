using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        multiples = multiples.Where(num => num != 0);
        var numbers = Enumerable.Range(1, max - 1).ToArray();
        var result = from num in numbers
            where multiples.Any(divider => num % divider == 0)
                select num;
        
        return result.Sum();
    }
}
