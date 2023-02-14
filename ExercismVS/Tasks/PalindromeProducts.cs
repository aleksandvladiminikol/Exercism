using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        return GetPalidromeProducts(minFactor, maxFactor, Enumerable.Max);
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        return GetPalidromeProducts(minFactor, maxFactor, Enumerable.Min);
    }

    private static (int, IEnumerable<(int, int)>) GetPalidromeProducts(int minFactor, int maxFactor, Func<IEnumerable<int>, int> AggregateFunc)
    {

        var products = Products(minFactor, maxFactor);
        var palindromes = Palindomes(products.Keys);


        var targetKey = AggregateFunc(palindromes);

        List<(int, int)> targetValues;
        products.TryGetValue(targetKey, out targetValues!);

        return (targetKey, targetValues);
    }

    private static Dictionary<int, List<(int, int)>> Products(int min, int max)
    {
        var res = new Dictionary<int, List<(int, int)>>();

        for (int i = min; i <= max; i++)
        {
            for (int j = min; j <= max; j++)
            {
                var key = i * j;
                List<(int, int)>? values;
                res.TryGetValue(key, out values);
                if (values == null)
                    values = new List<(int, int)>();
                var newPair = (Math.Min(i, j), Math.Max(i, j));
                if (!values.Exists(p => p==newPair))
                    values.Add(newPair);
                res.TryAdd(key, values);
            }
        }
        if (res.Count == 0) throw new ArgumentException();

        return res;
    }

    private static IEnumerable<int> Palindomes(IEnumerable<int> products)
    {
        var result = products.Where(x => IsPalindrome(x)).ToArray();
        if (result.Length == 0) throw new ArgumentException();
        return result;        
    }

    private static bool IsPalindrome(int number)
    {
        var view = number.ToString();
        return view.Reverse().SequenceEqual(view);
    }

}
