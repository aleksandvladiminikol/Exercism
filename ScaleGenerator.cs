namespace Exercism;

using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    public static string[] Chromatic(string tonic) =>
        usesharps.Contains(tonic) ? 
            Enumerable.Range(0, sharps.Count)
                .Select(t => sharps
                    .ElementAt((t + sharps.IndexOfIgnoringCase(tonic)) % sharps.Count))
                .ToArray() :
            Enumerable.Range(0, flats.Count)
                .Select(t => flats
                    .ElementAt((t + flats.IndexOfIgnoringCase(tonic)) % flats.Count))
                .ToArray();
    public static string[] Interval(string tonic, string pattern) =>
        Enumerable.Range(0, pattern.Length)
            .Select(t => Chromatic(tonic)[Enumerable.Range(0, t)
                .Select(i => Intervals[pattern[i]]).Sum()])
            .ToArray();
    private static readonly List<string> sharps = new List<string>
        (new string[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" });
    private static readonly List<string> flats = new List<string>
        (new string[] { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" });
    private static readonly List<string> usesharps = new List<string>
        (new string[] { "G", "D", "A", "E", "B", "F#", "e", "b", "f#", "c#", "g#", "d#", "C", "a" });
    private static readonly Dictionary<char, int> Intervals = new Dictionary<char, int>()
        { {'m', 1 }, {'M', 2 }, {'A', 3 } };
    private static int IndexOfIgnoringCase(this List<string> list, string text) =>
        Enumerable.Range(0, list.Count)
            .Where(i => text.Equals(list[i], 
                StringComparison.OrdinalIgnoreCase))
            .First(); 
}