using System.Text;

namespace Exercism;

using System;

public static class ResistorColorDuo
{
    public static List<string> _colors = new List<string>() 
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
        "white"
    };
    
    public static int Value(string[] colors)
    {
        var res = new StringBuilder();
        var counter = 0;
        foreach (var color in colors)
        {
            var index = _colors.FindIndex(s => s == color.ToLower());
            
            if (index >= 0)
            {
                res.Append(index.ToString());
            }

            counter++;
            
            if (counter > 1)
                break;
            
        }
        return Int32.Parse(res.ToString());
    }
}