using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Exercism;

public static class ScrabbleScore
{
    public static int Score(string input)
    {
        var rules = GetRules();
        int score = 0;
        int _score = 0;
        foreach (char item in input)
        {
            rules.TryGetValue(item.ToString().ToUpper(), out _score);
            score += _score;
        }    
        return score;
    }

    public static Dictionary<string, int> GetRules()
    {
        Dictionary<string, int> result = new();
        result.Add("A", 1);
        result.Add("E", 1);
        result.Add("I", 1);
        result.Add("O", 1);
        result.Add("U", 1);
        result.Add("L", 1);
        result.Add("N", 1);
        result.Add("R", 1);
        result.Add("S", 1);
        result.Add("T", 1);
        result.Add("D", 2);
        result.Add("G", 2);
        result.Add("B", 3);
        result.Add("C", 3);
        result.Add("M", 3);
        result.Add("P", 3);
        result.Add("F", 4);
        result.Add("H", 4);
        result.Add("V", 4);
        result.Add("W", 4);
        result.Add("Y", 4);
        result.Add("K", 5);
        result.Add("J", 8);
        result.Add("X", 8);
        result.Add("Q", 10);
        result.Add("Z", 10);

        return result;
    }

}

