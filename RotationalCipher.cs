using System.Text;

namespace Exercism;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var result = new StringBuilder();
        foreach (char sym in text)
        {
            result.Append(Decode(sym, shiftKey));
        }

        return result.ToString();
    }

    private static char Decode(char symbol, int shiftkey)
    {
        int min_lower = 65;
        int max_lower = 90;
        int min_upper = 97;
        int max_upper = 122;

        char result = symbol;
        if (symbol >= min_lower && symbol <= max_lower)
        {
            int expectedPos = symbol + shiftkey;
            result = (char) ((expectedPos > max_lower) ? min_lower + (expectedPos - max_lower - 1) : expectedPos);
        }
        if (symbol >= min_upper && symbol <= max_upper)
        {
            int expectedPos = symbol + shiftkey;
            result = (char) ((expectedPos > max_upper) ? min_upper + (expectedPos - max_upper - 1) : expectedPos);
        }

        return result;
    }
    
    
}