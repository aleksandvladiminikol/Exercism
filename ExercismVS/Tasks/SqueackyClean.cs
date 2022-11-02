using System.Text;

namespace Exercism;

using System;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder result = new();
        char[] input = identifier.ToCharArray();

        for (int i = 0; i<input.Length; i++)
        {
            char var = input[i];
            char symbol = var;
            if (char.IsWhiteSpace(var))
            {
                result.Append('_');
                continue;
            }

            if (char.IsControl(var))
            {
                result.Append("CTRL");
                continue;
            }

            if (var == '-')
            {
                i++;
                result.Append(input[i].ToString().ToUpper());
                continue;
            }

            if (var >= 'α' && var <= 'ω')
            {
                continue;
            }
            
            if (char.IsLetter(var))
            {
                result.Append(symbol);
            }
            
        }
        return result.ToString();
    }
}
