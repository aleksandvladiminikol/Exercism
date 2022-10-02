namespace Exercism;

using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        return moment + TimeSpan.FromSeconds(1_000_000_000);
    }
}