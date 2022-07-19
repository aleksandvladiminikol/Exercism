using System.Text;

namespace Exercism;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        StringBuilder result = new();
        var length = input.Length - 1;
        for (var i = length; i >= 0; i--)
        {
            result.Append(input[i]);
        }

        return result.ToString();
    }
}