using System.Text;

namespace Exercism;

public static class MatchingBrackets
{
    
    private static Dictionary<char, char> rules = new Dictionary<char, char>()
    {
        {'{', '}'},
        {'(', ')'},
        {'[', ']'},
    };

    private static string closingBrackets = "}])";
    public static bool IsPaired(string input)
    {
        var length = input.Length;
        
        var openingBrackets = 0;
        var factEnding = "";
        foreach (var element in input)
        {
            char closing;
            if (rules.TryGetValue(key: element, out closing))
            {
                factEnding = factEnding + closing;
                openingBrackets++;
            }
            else if (closingBrackets.Contains(element))
            {
                openingBrackets--;
                if (factEnding.EndsWith(element))
                {
                    factEnding = factEnding.Remove(factEnding.LastIndexOf(element));
                }
            }
        }
        return (factEnding.Length == 0 && openingBrackets == 0);
    }
}