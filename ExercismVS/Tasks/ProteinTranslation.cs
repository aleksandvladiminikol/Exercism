namespace Exercism;

using System.Linq;
using System.Collections.Generic;
public class ProteinTranslation
{
    private static readonly Dictionary<string, string> _rules = new()
    {
        {"AUG", "Methionine"},
        {"UUU", "Phenylalanine"},
        {"UUC", "Phenylalanine"},
        {"UUA", "Leucine"},
        {"UUG", "Leucine"},
        {"UCU", "Serine"},
        {"UCC", "Serine"},
        {"UCA", "Serine"},
        {"UCG", "Serine"},
        {"UAU", "Tyrosine"},
        {"UAC", "Tyrosine"},
        {"UGU", "Cysteine"},
        {"UGC", "Cysteine"},
        {"UGG", "Tryptophan"},
        {"UAA", "STOP"},
        {"UAG", "STOP"},
        {"UGA", "STOP"},
    };
    static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
    public static string[] Proteins(string strand)
    {
        var cotons = Split(strand, 3).ToList();
        var resultSize = cotons.Count;
        var result = new List<string>();

        string protein = "";
        int counter = 0;

        foreach (var coton in cotons)
        {
            _rules.TryGetValue(coton, out protein);
            if (protein == "STOP")
                break;
            result.Add(protein);
        }

        return result.ToArray();
    }
}