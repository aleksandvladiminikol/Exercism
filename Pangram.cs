using System.Collections;
using System.Collections.Generic;

namespace Exercism;

using System;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        List<int> alphabet = new();
        for (int i = 97; i<=122; i++)
        {
            alphabet.Add(i);
        }
        foreach (char sym in input.ToLower())
        {
            alphabet.Remove((int) sym);
        }

        return alphabet.Count == 0;
    }
}
