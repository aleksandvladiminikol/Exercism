using System;
using System.Linq;
using System.Collections.Generic;
public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        var validCoins = coins.Where(c => c <= target).Reverse();
        var result = TryFindFewestCoins(validCoins, target);
        
        if (result == null)
        {
            throw new ArgumentException("No combination of coins can make up the target value.");
        }
        
        return result.ToArray();
    }
    
    private static List<int>? TryFindFewestCoins(IEnumerable<int> coins, int target)
    {
        if (target == 0)
        {
            return new List<int>();
        }
        
        var possibleResults = new List<List<int>>();
        
        foreach (var coin in coins)
        {
            if (coin > target)
            {
                continue;
            }
            
            var maxAmount = target / coin;
            var remainingTarget = target;
            var currentResult = new List<int>();
            
            foreach (var i in Enumerable.Range(1, maxAmount).Reverse())
            {
                var remaining = remainingTarget - coin * i;
                var subResult = TryFindFewestCoins(coins.Where(c => c < coin), remaining);
                
                if (subResult == null)
                {
                    continue;
                }
                
                currentResult.AddRange(subResult);
                currentResult.AddRange(Enumerable.Repeat(coin, i));
                remainingTarget -= currentResult.Sum();
                break;
            }
            
            if (remainingTarget == 0)
            {
                possibleResults.Add(currentResult);
            }
        }
        return possibleResults.MinBy(r => r.Count);
    }
}
