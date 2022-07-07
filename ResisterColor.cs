namespace Exercism;

using System;

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        string[] resistors = Colors();
        return Array.IndexOf(resistors, color.ToLower());
    }

    public static string[] Colors()
    {
        string[] resistors = new string[10]
        {
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white",
        };
        return resistors;
    }
}