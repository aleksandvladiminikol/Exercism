namespace Exercism;

using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        List<int> alphabet = new();
        
        foreach (char sym in word.ToLower())
        {
            if (alphabet.Exists(i => i == sym))
            {
                return false;
            }

            if (sym >= 97 && sym <= 122)
            {
                alphabet.Add(sym);
            }
        }
        return true;
    }
}