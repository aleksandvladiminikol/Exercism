using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        ConcurrentDictionary<char, int> map = new ConcurrentDictionary<char, int>();
        Parallel.ForEach(texts, (text) => {
            foreach (char c in text)
                if (char.IsLetter(c))
                    map.AddOrUpdate(char.ToLower(c), 1, (k, v) => v + 1);
        });
        return map.ToDictionary(x => x.Key, x => x.Value);
    }
}