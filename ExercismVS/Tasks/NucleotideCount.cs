using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    private static readonly Dictionary<char, int> Template = new ()
    {
        ['A'] = 0,
        ['C'] = 0,
        ['G'] = 0,
        ['T'] = 0
    };
    
    public static IDictionary<char, int> Count(string sequence)
    {
        foreach (var nucleotide in Template.Keys)
        {
            Template[nucleotide] = sequence.Count(_ => _ == nucleotide);
        }

        if (Template.Values.Sum() != sequence.Length)
        {
            throw new ArgumentException();
        }
        return Template;
    }
}