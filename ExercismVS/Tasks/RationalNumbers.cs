using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    private static int _gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }
    public RationalNumber(int numerator, int denominator)
    {
        var gcd = _gcd(numerator, denominator);
        var k = denominator < 0 ? -1 : 1;
        Numerator = numerator * k / gcd;
        Denominator = denominator * k / gcd;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator,r1.Denominator * r2.Denominator);
        
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator,r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator, r2.Numerator * r1.Denominator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
    }

    public RationalNumber Reduce()
    {
        return new RationalNumber(Numerator, Denominator);
    }

    public RationalNumber Exprational(int power)
    {
        var numerator = Numerator;
        var denominator = Denominator;
        if (power < 0)
        {
             numerator = Denominator;
             denominator = Numerator;
        }
        power = Math.Abs(power);
        return new RationalNumber((int)Math.Pow(numerator, power), (int) Math.Pow(denominator, power));
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(baseNumber, Numerator / (double)Denominator); 
    }
}