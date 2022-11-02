namespace Exercism;

using System;
using System.Numerics;

public static class DiffieHellman
{
    private static readonly Random _randomizer = new();
    public static BigInteger PrivateKey(BigInteger primeP)
    {
        var bytes = primeP.ToByteArray();
        BigInteger R;

        do {
            _randomizer.NextBytes(bytes);
            bytes [^1] &= (byte)0x7F;
            R = new BigInteger (bytes);
        } while (R >= primeP);

        return R;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) 
    {
        return BigInteger.Pow(primeG, (int) privateKey) % primeP;
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) 
    {
        return BigInteger.Pow(publicKey, (int) privateKey) % primeP;
    }
}