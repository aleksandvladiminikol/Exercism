using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        var groupedDice = (
            from i in dice.GroupBy(i => i)
            orderby i.Count() descending 
            select i)
            .ToArray();
        return (int) category switch
        {
            var i and <= 6 => dice.Count(i1 => i1 == i) * i,
            7 => groupedDice.Length == 2 && groupedDice[0].Count() == 3 ? dice.Sum() : 0,
            8 => groupedDice.Length <= 2 && groupedDice[0].Count() >= 4 ? groupedDice[0].Key * 4 : 0,
            9 => groupedDice.Length == 5 && dice.Max() != 6 ? 30 : 0,
            10 => groupedDice.Length == 5 && dice.Min() != 1 ? 30 : 0,
            12 => groupedDice.Length == 1 ? 50 : 0,
            _ => dice.Sum()
        };
    }
}