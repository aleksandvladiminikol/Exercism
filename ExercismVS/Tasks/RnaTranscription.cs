using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> Rules = new()
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U',
    };

    public static string ToRna(string nucleotide)
    {
        return string.Concat(nucleotide.Select(_ => Rules.TryGetValue(_, out var value) ? value : _));
    }
}