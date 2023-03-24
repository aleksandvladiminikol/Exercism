using System;
using System.Collections.Generic;
public static class BeerSong
{
    private const int MaxBottles = 99;
    private const string SingleBottle = "{0} bottle";
    private const string PluralBottle = "{0} bottles";
    private const string NoBottles = "No more bottles";
    private const string BottlesOnWallTemplate = "{0} of beer on the wall, {1} of beer.";
    private const string PassBeerTemplate = "Take one down and pass it around, {0} of beer on the wall.";
    private const string PassLastBeerTemplate = "Take it down and pass it around, {0} of beer on the wall.";
    
    private const string GoToStoreTemplate =
        "Go to the store and buy some more, {0} bottles of beer on the wall.";

    private static string BottlesString(int bottles)
    {
        return bottles switch
        {
            0 => NoBottles,
            1 => string.Format(SingleBottle, bottles),
            _ => string.Format(PluralBottle, bottles),

        };
    }

    public static string Recite(int startBottles, int takeDown)
    {
        var song = new List<string>();
        for (var bottle = startBottles; bottle > startBottles - takeDown; bottle--)
        {
            var bottlesString = BottlesString(bottle);
            var firstLine = string.Format(BottlesOnWallTemplate, bottlesString, bottlesString.ToLower());
            var secondLine = (bottle) switch
            {
                1 => string.Format(PassLastBeerTemplate, BottlesString(bottle - 1).ToLower()),
                0 => string.Format(GoToStoreTemplate, MaxBottles),
                _ => string.Format(PassBeerTemplate, BottlesString(bottle - 1).ToLower())
            };
            song.Add(firstLine + "\n" + secondLine);
        }

        return string.Join("\n\n", song);
    }
}