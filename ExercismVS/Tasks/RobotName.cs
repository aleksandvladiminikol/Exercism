using System.Text;
using System.Collections.Generic;


namespace Exercism;

using System;

public static class Cache<T>
{
    private static HashSet<T> _cache = new HashSet<T>();
    public static bool Add(T name) => _cache.Add(name);
}

public class Robot
{
    private string _name = string.Empty;
    public string Name
    {
        get
        {
            if (_name == string.Empty)
            {
                do
                {
                    _name = RandomName();
                } while (!Cache<string>.Add(_name));
            }

            return _name;
        }
    }

    public void Reset()
    {
        _name = string.Empty;
    }

    private string RandomName()
    {
        int min_upper = 65;
        int max_upper = 91;
        var randomizer = new Random();
        var result = new StringBuilder();
        for (int i = 0; i < 2; i++)
        {
            result.Append((char) randomizer.Next(min_upper, max_upper));
        }
        for (int i = 0; i < 3; i++)
        {
            result.Append(randomizer.Next(0, 9));
        }

        return result.ToString();

    }
}