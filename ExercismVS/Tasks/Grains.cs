using System;
public static class Grains
{
    private const int Min = 1;
    private const int Max = 64;

    public static ulong Square(int n) => (ulong) Math.Pow(2, ValidateInput(n));

    public static ulong Total() => ulong.MaxValue;

    public static ulong _Total() => Enumerable.Range(0, 63).Aggregate<int, ulong>(0, (current, pow) => current + (ulong) Math.Pow(2, pow));
    
    private static int ValidateInput(int n)
    {
        if (n is < Min or > Max)
            throw new ArgumentOutOfRangeException();
        return n - 1;
    }
}